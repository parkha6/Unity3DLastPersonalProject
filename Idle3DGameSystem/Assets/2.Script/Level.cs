using UnityEngine;
/// <summary>
/// 레벨업 관련 클래스
/// </summary>
public class Level : MonoBehaviour
{
    /// <summary>
    /// 현재 레벨을 넣으면 1 오른다.
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    internal byte IncreaseLevel(byte currentLevel)
    {
        if (currentLevel >= Consts.maxLevel)
        { currentLevel = Consts.maxLevel; }
        else if (currentLevel <= Consts.none)
        { currentLevel = Consts.minValue; }
        else
        { ++currentLevel; }
        return currentLevel;
    }
    /// <summary>
    /// 현재값과 더하려는 값을 넣으면 더한 값을 리턴한다.
    /// 공격력 증가, 방어력 증가용.
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="plusValue"></param>
    /// <returns></returns>
    internal int RandomIncreaseValue(bool isBar)
    {
        byte plusValue = (byte)Random.Range(Consts.minValue, Consts.plusStatPoint);
        if (isBar)
        { plusValue *= Consts.barStat; }
        return plusValue;
    }
}
