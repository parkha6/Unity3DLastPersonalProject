using UnityEngine;
/// <summary>
/// 모든 오브젝트의 공통변수를 가진 클래스
/// </summary>
public class Object : MonoBehaviour
{
    /// <summary>
    /// 이름 변수
    /// </summary>
    internal string nameIs = "알 수 없음";
    /// <summary>
    /// 레벨 변수
    /// </summary>
    protected byte level = Consts.minValue;
    /// <summary>
    /// 255이상과 음수값을 막기 위한 레벨 프로퍼티
    /// </summary>
    internal byte Level
    {
        get { return level; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            else if (value >= Consts.maxLevel)
            { value = Consts.maxLevel; }
            level = value;
        }
    }
    /// <summary>
    /// 공격력 변수
    /// </summary>
    protected int atk = Consts.minValue;
    /// <summary>
    /// 공격력 프로퍼티
    /// </summary>
    internal int Atk
    {
        get { return atk; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            atk = value;
        }
    }
    /// <summary>
    /// 방어력 변수
    /// </summary>
    protected int def = Consts.minValue;
    /// <summary>
    /// 방어력 프로퍼티
    /// </summary>
    internal int Def
    {
        get { return def; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            def = value;
        }
    }
}
class item : Object
{
    /// <summary>
    /// 아이템의 스프라이트 아이콘을 넣는 자리입니다.
    /// </summary>
    [Tooltip("아이템의 스프라이트 아이콘을 넣는 자리입니다.")]
    [SerializeField] Sprite icon;
    /// <summary>
    /// 아이템의 가격
    /// </summary>
    int price = Consts.none;
    /// <summary>
    /// 레벨업 시 소모골드
    /// </summary>
    int lvUpPrice = Consts.minValue;
    /// <summary>
    /// 장착여부 확인
    /// </summary>
    bool isEquip = false;
    /// <summary>
    /// 아이템 습득
    /// </summary>
    void GetItem() { }
    /// <summary>
    /// 아이템 감소
    /// </summary>
    void RidItem() { }
    /// <summary>
    /// 아이템 구매
    /// </summary>
    void BuyItem() { }
    /// <summary>
    /// 아이템 판매
    /// </summary>
    void SellItem() { }
}
class BattleUnit : Object
{
    /// <summary>
    /// 총 체력
    /// </summary>
    protected int hp = Consts.minValue;
    /// <summary>
    /// 총 체력 프로퍼티
    /// </summary>
    internal int Hp
    {
        get { return hp; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            hp = value;
            currentHp = hp;
        }
    }
    /// <summary>
    /// 현재 체력
    /// </summary>
    protected int currentHp = Consts.minValue;
    /// <summary>
    /// 현재 체력 프로퍼티
    /// </summary>
    internal int CurrentHp
    {
        get { return currentHp; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            currentHp = value;
        }
    }
    /// <summary>
    /// 총 마력
    /// </summary>
    protected int mp = Consts.minValue;
    /// <summary>
    /// 총마력 프로퍼티
    /// </summary>
    internal int Mp
    {
        get { return mp; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            mp = value;
            currentMp = mp;
        }
    }
    /// <summary>
    /// 현재 마력
    /// </summary>
    protected int currentMp = Consts.minValue;
    /// <summary>
    /// 현재 마력 프로퍼티
    /// </summary>
    internal int CurrentMp
    {
        get { return currentMp; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            currentMp = value;
        }
    }
    /// <summary>
    /// 데미지 수치
    /// </summary>
    protected int damage = Consts.minValue;
    /// <summary>
    /// 죽음 판정
    /// </summary>
    protected bool isDead = false;
    /// <summary>
    /// 죽음 체크용 프로퍼티
    /// </summary>
    internal bool IsDead { get { return isDead; } }
    /// <summary>
    /// 공격데미지 계산
    /// </summary>
    internal int Attack()
    { return damage = Atk; }
    /// <summary>
    /// 외부호출용 데미지 함수
    /// </summary>
    /// <param name="otherDmg"></param>
    internal virtual void GetAttacked(int otherDmg)
    { GetDamaged(otherDmg); }
    /// <summary>
    /// Hp 배치용 함수
    /// </summary>
    /// <param name="otherDmg"></param>
    protected void GetDamaged(int otherDmg)
    { ReduceHp(Damaged(otherDmg)); }
    /// <summary>
    /// 맞고 남은 체력를 돌려줌
    /// </summary>
    int Damaged(int otherDmg)
    {
        otherDmg -= def;
        Debug.Log($"들어온 데미지{otherDmg}");
        Debug.Log($"유닛 방어력{def}");
        if (otherDmg <= Consts.none)
        {
            Debug.Log($"남은 공격력{otherDmg}");
            Debug.Log($"{nameIs}방어 성공");
            return otherDmg = Consts.none;
        }
        else
        { return otherDmg; }
    }
    /// <summary>
    /// hpDmg만큼 체력을 깎고 돌려준다.
    /// 체력이 0이 되면 죽음 상태가 된다.
    /// </summary>
    /// <param name="hpDmg"></param>
    /// <returns></returns>
    protected void ReduceHp(int hpDmg)
    {
        Debug.Log($"들어온 데미지{hpDmg}");
        Debug.Log($"현재 Hp{CurrentHp}");
        if (hpDmg >= 0)
        {
            CurrentHp -= hpDmg;
            if (CurrentHp <= Consts.none)
            {
                CurrentHp = Consts.dead;
                Dead();
            }
        }
        Debug.Log($"피격 후 Hp{CurrentHp}");
    }
    /// <summary>
    /// usedMp에 사용mp값을 입력하면 기술을 쓸수 있는지 없는지 판단해서 돌려준다.
    /// </summary>
    /// <param name="usedMp"></param>
    /// <returns></returns>
    protected bool ReduceMp(int usedMp)
    {
        if (CurrentMp - usedMp < Consts.none)
        {
            Debug.Log("Mp가 부족합니다.");
            return false;
        }
        else
        {
            CurrentMp -= usedMp;
            return true;
        }
    }
    /// <summary>
    /// increaseDMG만큼 데미지를 더해서 돌려준다.
    /// </summary>
    /// <param name="increaseDmg"></param>
    /// <returns></returns>
    protected int DamageIncrease(int increaseDmg)
    { return damage += increaseDmg; }
    /// <summary>
    /// 가지고 있는 골드 수치
    /// </summary>
    int gold = Consts.none;
    /// <summary>
    /// 드랍 골드 프로퍼티
    /// </summary>
    internal int Gold
    {
        get { return gold; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            gold = value;
        }
    }
    /// <summary>
    /// plusGold만큼 골드 값 증가.
    /// </summary>
    /// <param name="plusGold"></param>
    /// <returns></returns>
    internal int IncreaseGold(int plusGold)
    { return Gold += plusGold; }
    /// <summary>
    /// 죽었으면 isDead를 true로 바꿔줌.
    /// </summary>
    protected virtual void Dead()
    { isDead = true; }
    internal int DecreaseGold(int minusGold)
    { return Gold -= minusGold; }
    /// <summary>
    /// 재시작용 체력회복 함수
    /// </summary>
    internal void StartAgain()
    {
        CurrentHp = Hp;
        isDead = false;
    }
}