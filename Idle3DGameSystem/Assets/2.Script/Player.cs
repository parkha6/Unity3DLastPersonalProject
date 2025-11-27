using UnityEngine;
/// <summary>
/// 플레이어 클래스
/// </summary>
internal class Player : BattleUnit
{
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
    /// 경험치 초기화
    /// </summary>
    /// <returns></returns>
    int ResetExp()
    { return CurrentExp = Consts.none; }
    /// <summary>
    /// plusExp만큼 경험치를 증가시킴.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    internal int IncreaseExp(int plusExp)
    { return CurrentExp += plusExp; }
    /// <summary>
    /// plusExp만큼 총 경험치 증가.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    int IncreaseWholeExp(int plusExp)
    { return exp += plusExp; }
    /// <summary>
    /// plusHp만큼 총 체력 증가.
    /// </summary>
    /// <param name="plusHp"></param>
    /// <returns></returns>
    int IncreaseWholeHp(int plusHp)
    { return hp += plusHp; }
    /// <summary>
    /// plusMp만큼 총 마력 증가.
    /// </summary>
    /// <param name="plusMp"></param>
    /// <returns></returns>
    int IncreaseWholeMp(int plusMp)
    { return mp += plusMp; }
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
        Atk = Random.Range(Consts.minValue, Consts.maxPlusStat);
        Def = Random.Range(Consts.minValue, Consts.maxPlusStat);
    }
    /// <summary>
    /// 플레이어는 여기서 Hp가 UI창에 반영됨
    /// </summary>
    /// <param name="otherDmg"></param>
    internal override void GetAttacked(int otherDmg)
    { 
        GetDamaged(otherDmg);
        UiManager.Instance.SetHp(CurrentHp,Hp);
        Debug.Log($"플레이어 Hp 호출 체크 {CurrentHp}/{Hp}");
    }
}