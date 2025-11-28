using System.Collections;
using UnityEngine;
/// <summary>
/// 몬스터 클래스
/// </summary>
class Monster : BattleUnit
{
    /// <summary>
    /// 박스 애니메이션
    /// </summary>
    [SerializeField] Animator boxAnimator;
    /// <summary>
    /// 드랍하는 경험치 수치
    /// </summary>
    int dropExp = Consts.none;
    /// <summary>
    /// 드랍 경험치 프로퍼티
    /// </summary>
    internal int DropExp
    {
        get { return dropExp; }
        set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            dropExp = value;
        }
    }
    /// <summary>
    /// 드랍하는 아이템
    /// </summary>
    item dropItem;
    /// <summary>
    /// 보상 드립 함수
    /// </summary>
    internal void DropReward(Player player)
    {
        if (isDead)
        {
            player.IncreaseGold(Gold);
            player.IncreaseExp(dropExp);
        }
    }
    /// <summary>
    /// 몬스터 전용으로 오버라이드 된 공격받는 함수
    /// </summary>
    /// <param name="otherDmg"></param>
    internal override void GetAttacked(int otherDmg)
    { StartCoroutine(GetAttackedRepeat(otherDmg)); }
    /// <summary>
    /// 공격받으면 코루틴으로 맞는 애니메이션 재생함
    /// </summary>
    /// <param name="otherDmg"></param>
    /// <returns></returns>
    IEnumerator GetAttackedRepeat(int otherDmg)
    {
        bool isStart = true;
        while (isStart)
        {
            boxAnimator.SetBool("damaged", true);
            GetDamaged(otherDmg);
            yield return new WaitForSeconds(Consts.waitingTime);
            boxAnimator.SetBool("damaged", false);
            isStart = false;
        }
    }
    /// <summary>
    /// 몬스터 전용 죽음 함수
    /// </summary>
    protected override void Dead()
    {
        isDead = true;
        boxAnimator.SetBool("isDead", isDead);
    }
}