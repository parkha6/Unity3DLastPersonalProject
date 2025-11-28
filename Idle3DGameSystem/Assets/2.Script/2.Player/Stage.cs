using UnityEngine;

public class Stage : MonoBehaviour
{
    /// <summary>
    /// 메인 스테이지
    /// </summary>
    int mainStage = Consts.minValue;
    /// <summary>
    /// 메인스테이지 음수 방지 프로퍼티
    /// </summary>
    internal int MainStage
    {
        get { return mainStage; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            else if (value > Consts.maxInt)
            { value = Consts.maxInt; }
                mainStage = value;
        }
    }
    /// <summary>
    /// 서브 스테이지
    /// </summary>
    int subStage = Consts.minValue;
    /// <summary>
    /// 서브스테이지 음수 방지+ 자동 스테이지 업용 프로퍼티
    /// </summary>
    internal int SubStage
    {
        get { return subStage; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.minValue; }
            else if (value >= Consts.endSubStage)
            {
                if (MainStage < Consts.maxInt)
                {
                    ++MainStage;
                    value = Consts.minValue;
                }
            }
            else if (value > Consts.maxInt)
            { value = Consts.maxInt; }
                subStage = value;
        }
    }
    /// <summary>
    /// 스테이지 상승용 함수
    /// </summary>
    internal int IncreaseStage()
    { return ++SubStage; }
}
