/// <summary>
/// 몬스터 클래스
/// </summary>
class Monster : BattleUnit
{
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
}