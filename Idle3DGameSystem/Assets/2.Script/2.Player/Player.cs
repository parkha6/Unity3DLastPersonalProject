using System.Collections;
using UnityEngine;
/// <summary>
/// 플레이어 클래스
/// </summary>
internal class Player : BattleUnit
{
    /// <summary>
    /// 레벨 클래스 넣는 변수
    /// </summary>
    [Tooltip("레벨 클래스 넣는 변수")]
    [SerializeField] Level levelClass;
    /// <summary>
    /// 플레이어 맞는 애니메이션
    /// </summary>
    [Tooltip("플레이어 맞는 애니메이션")]
    [SerializeField] Animator playerAnimator;
    /// <summary>
    /// 스텟포인트
    /// </summary>
    int statPoint = Consts.none;
    /// <summary>
    /// 스텟포인트 읽기 전용
    /// </summary>
    internal int StatPoint { get { return statPoint; } }
    /// <summary>
    /// 총 경험치
    /// </summary>
    int exp = Consts.minValue;
    /// <summary>
    /// 총 경험치 프로퍼티
    /// </summary>
    internal int Exp { get { return exp; } }
    /// <summary>
    /// 현재 경험치
    /// </summary>
    int currentExp = Consts.none;
    /// <summary>
    /// 현재 경험치 프로퍼티
    /// </summary>
    internal int CurrentExp
    {
        get { return currentExp; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            currentExp = value;
        }
    }
    /// <summary>
    /// plusExp만큼 경험치를 증가시키고 현재 경험치가 전체경험치보다 많으면 레벨을 올린다.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    internal int IncreaseExp(int plusExp)
    {
        CurrentExp += plusExp;
        UiManager.Instance.SetExp(CurrentExp, Exp);
        while (CurrentExp >= Exp)
        { SetLevelUp(); }
        return currentExp;
    }
    /// <summary>
    /// 레벨업 할때 세팅
    /// </summary>
    void SetLevelUp()
    {
        currentExp -= Exp;
        if (Level < Consts.maxLevel)
        {
            Level = levelClass.IncreaseLevel(Level);
            UiManager.Instance.LevelText(Level);
        }
        if (exp < Consts.maxInt - Consts.barStat)
        {
            exp += Consts.barStat;
            UiManager.Instance.SetExp(CurrentExp, Exp);
        }
        else if (exp < Consts.maxInt && exp > Consts.maxInt - Consts.barStat)
        {
            exp = Consts.maxInt;
            UiManager.Instance.SetExp(CurrentExp, Exp);
        }

        if (statPoint < Consts.maxInt - Consts.plusStatPoint)
        {
            statPoint += Consts.plusStatPoint;
            UiManager.Instance.SetPoint(StatPoint);
            UiManager.Instance.SetUpButton(true);
        }
        else if ((statPoint < Consts.maxInt && statPoint > Consts.maxInt - Consts.plusStatPoint))
        {
            statPoint = Consts.maxInt;
            UiManager.Instance.SetPoint(StatPoint);
            UiManager.Instance.SetUpButton(true);
        }
    }
    /// <summary>
    /// 버튼 누르면 체력 10오름
    /// </summary>
    internal void SetHpUp()
    {
        if (statPoint > 0)
        {
            --statPoint;
            Hp += Consts.barStat;
            UiManager.Instance.SetHp(CurrentHp, Hp);
            UiManager.Instance.SetPoint(StatPoint);
        }
        else if (Hp == Consts.maxInt)
        { UiManager.Instance.DeactiveHpUp(); }
        if (statPoint <= 0)
        { UiManager.Instance.SetUpButton(false); }
    }
    /// <summary>
    /// 버튼 누르면 마력 10오름
    /// </summary>
    internal void SetMpUp()
    {
        if (statPoint > 0)
        {
            --statPoint;
            Mp += Consts.barStat;
            UiManager.Instance.SetMp(CurrentMp, Mp);
            UiManager.Instance.SetPoint(StatPoint);
        }
        else if (Mp == Consts.maxInt)
        { UiManager.Instance.DeactiveMpUp(); }
        if (statPoint <= 0)
        { UiManager.Instance.SetUpButton(false); }
    }
    /// <summary>
    /// 버튼 누르면 공격력 1오름
    /// </summary>
    internal void SetAtkUp()
    {
        if (statPoint > 0)
        {
            --statPoint;
            ++Atk;
            UiManager.Instance.SetAtk(Atk);
            UiManager.Instance.SetPoint(StatPoint);
        }
        else if (Atk == Consts.maxInt)
        { UiManager.Instance.DeactiveAtkUp(); }
        if (statPoint <= 0)
        { UiManager.Instance.SetUpButton(false); }
    }
    /// <summary>
    /// 버튼 누르면 방어력 1오름
    /// </summary>
    internal void SetDefUp()
    {
        if (statPoint > 0)
        {
            --statPoint;
            ++Def;
            UiManager.Instance.SetDef(Def);
            UiManager.Instance.SetPoint(StatPoint);
        }
        else if (Def == Consts.maxInt)
        { UiManager.Instance.DeactiveDefUp(); }
        if (statPoint <= 0)
        { UiManager.Instance.SetUpButton(false); }
    }
    /// <summary>
    /// 이름 입력 함수
    /// </summary>
    /// <param name="inputName"></param>
    internal void InputName(string inputName)
    { nameIs = inputName; }
    /// <summary>
    /// 초기 플레이어 스텟 세팅
    /// </summary>
    internal void InitialStatSetting()
    {
        Hp = Level * Consts.barStat;
        Mp = Level * Consts.barStat;
        exp = Level * Consts.barStat;
        Atk = Consts.minValue;
        Def = Consts.none;
    }
    /// <summary>
    /// 플레이어는 여기서 Hp가 UI창에 반영됨
    /// </summary>
    /// <param name="otherDmg"></param>
    internal override void GetAttacked(int otherDmg)
    { StartCoroutine(DamagedAnimation(otherDmg)); }
    /// <summary>
    /// 맞는 애니메이션 재생용 코루틴
    /// </summary>
    /// <param name="otherDmg"></param>
    /// <returns></returns>
    IEnumerator DamagedAnimation(int otherDmg)
    {
        bool isStart = true;
        while (isStart)
        {
            playerAnimator.SetBool("isDamaged", true);
            GetDamaged(otherDmg);
            UiManager.Instance.SetHp(CurrentHp, Hp);
            Debug.Log($"플레이어 Hp 호출 체크 {CurrentHp}/{Hp}");
            yield return new WaitForSeconds(Consts.waitingTime);
            playerAnimator.SetBool("isDamaged", false);
            isStart = false;
        }
    }
    /// <summary>
    /// 플레이어가 골드를 얻으면 UI
    /// </summary>
    /// <param name="plusGold"></param>
    /// <returns></returns>
    internal override int IncreaseGold(int plusGold)
    {
        Gold += plusGold;
        UiManager.Instance.SetGold(Gold);
        return Gold;
    }
}