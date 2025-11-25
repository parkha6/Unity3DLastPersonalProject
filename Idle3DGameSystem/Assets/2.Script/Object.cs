using UnityEngine;
/// <summary>
/// 모든 오브젝트의 공통변수를 가진 클래스
/// </summary>
public class Object : MonoBehaviour
{
    /// <summary>
    /// 이름 변수
    /// </summary>
    protected string nameIs = "알 수 없음";
    /// <summary>
    /// 레벨 변수
    /// </summary>
    protected byte level = 0;
    /// <summary>
    /// 255이상과 음수값을 막기 위한 레벨 프로퍼티
    /// </summary>
    internal byte Level
    {
        get { return level; }
        set
        {
            if (value <= 0)
            { value = 1; }
            else if (value > 255)
            { value = 255; }
            level = value;
        }
    }
    /// <summary>
    /// 공격력 변수
    /// </summary>
    protected int atk = 1;
    /// <summary>
    /// 방어력 변수
    /// </summary>
    protected int def = 1;
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
    int price = 0;
    /// <summary>
    /// 레벨업 시 소모골드
    /// </summary>
    int lvUpPrice = 0;
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
    protected int hp = 1;
    /// <summary>
    /// 현재 체력
    /// </summary>
    protected int currentHp = 1;
    /// <summary>
    /// 총 마력
    /// </summary>
    protected int mp = 1;
    /// <summary>
    /// 현재 마력
    /// </summary>
    protected int currentMp = 1;
    /// <summary>
    /// 데미지 수치
    /// </summary>
    protected int damage = 1;
    /// <summary>
    /// 죽음 판정
    /// </summary>
    protected bool isDead = false;
    /// <summary>
    /// 공격데미지 계산
    /// </summary>
    void Attack() { }
    /// <summary>
    /// 맞고 남은 체력를 돌려줌
    /// </summary>
    protected int Damaged(int otherDmg)
    {
        otherDmg -= def;
        if (otherDmg <= 0)
        {
            Debug.Log("방어 성공");
            return Consts.noDamage;
        }
        else
        { return reduceHp(otherDmg); }
    }
    /// <summary>
    /// hpDmg만큼 체력을 깎고 돌려준다.
    /// 체력이 0이 되면 죽음 상태가 된다.
    /// </summary>
    /// <param name="hpDmg"></param>
    /// <returns></returns>
    protected int reduceHp(int hpDmg)
    {
        currentHp -= hpDmg;
        if (currentHp <= 0)
        {
            currentHp = Consts.dead;
            Dead();
        }
        return currentHp;

    }
    /// <summary>
    /// usedMp에 사용mp값을 입력하면 기술을 쓸수 있는지 없는지 판단해서 돌려준다.
    /// </summary>
    /// <param name="usedMp"></param>
    /// <returns></returns>
    protected bool reduceMp(int usedMp)
    {
        if (currentMp - usedMp < 0)
        {
            Debug.Log("Mp가 부족합니다.");
            return false;
        }
        else
        {
            currentMp -= usedMp;
            return true;
        }
    }
    /// <summary>
    /// 죽었으면 isDead를 true로 바꿔줌.
    /// </summary>
    protected void Dead()
    { isDead = true; }
    /// <summary>
    /// increaseDMG만큼 데미지를 더해서 돌려준다.
    /// </summary>
    /// <param name="increaseDmg"></param>
    /// <returns></returns>
    protected int DamageIncrease(int increaseDmg)
    { return damage += increaseDmg; }
}

/// <summary>
/// 플레이어 클래스
/// </summary>
class Player : BattleUnit
{
    /// <summary>
    /// 총 경험치
    /// </summary>
    int exp = 1;
    /// <summary>
    /// 현재 경험치
    /// </summary>
    int currentExp = 0;
    /// <summary>
    /// 경험치 초기화
    /// </summary>
    /// <returns></returns>
    int ResetExp()
    { return currentExp = 0; }
    /// <summary>
    /// plusExp만큼 경험치를 증가시킴.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    int IncreaseExp(int plusExp)
    { return currentExp += plusExp; }
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
}
/// <summary>
/// 몬스터 클래스
/// </summary>
class Monster : BattleUnit
{
    /// <summary>
    /// 드랍하는 Exp 수치
    /// </summary>
    int dropExp = 0;
    /// <summary>
    /// 드랍하는 골드 수치
    /// </summary>
    int dropGold = 0;
    /// <summary>
    /// 드랍하는 아이템
    /// </summary>
    item dropItem;
    /// <summary>
    /// 보상 드립 함수
    /// </summary>
    void DropReward()
    { }
}
/// <summary>
/// 레벨업 관련 클래스
/// </summary>
class Level
{
    /// <summary>
    /// 현재 레벨을 넣으면 1 오른다.
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    int IncreaseLevel(int currentLevel)
    { return ++currentLevel; }
    /// <summary>
    /// 현재값과 더하려는 값을 넣으면 더한 값을 리턴한다.
    /// 공격력 증가, 방어력 증가용.
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="plusValue"></param>
    /// <returns></returns>
    int IncreaseAnything(int currentValue, int plusValue)
    { return currentValue + plusValue; }
}