using UnityEngine;
/// <summary>
/// 매직넘버 방지용 클래스
/// </summary>
class Consts
{
    /// <summary>
    /// 뭐든 없음
    /// </summary>
    internal const byte none = 0;
    /// <summary>
    /// 죽음상태에 쓰는 변수
    /// </summary>
    internal const byte dead = 0;
    /// <summary>
    /// 스테이지 시작
    /// </summary>
    internal const byte minValue = 1;
    /// <summary>
    /// 서브 스테이지 끝
    /// </summary>
    internal const byte endSubStage = 10;
    /// <summary>
    /// 최고레벨
    /// </summary>
    internal const byte maxLevel = 255;
    /// <summary>
    /// 첫번째 박스번호
    /// </summary>
    internal const byte firstMon = 0;
    /// <summary>
    /// 두번째 박스번호
    /// </summary>
    internal const byte secondMon = 1;
    /// <summary>
    /// 몬스터 2마리
    /// </summary>
    internal const byte twoMon = 2;
    /// <summary>
    /// 스텟이 오를 수 있는 최고수치
    /// </summary>
    internal const byte plusStatPoint = 5;
    /// <summary>
    /// 체력 마력 경험치 보정용
    /// </summary>
    internal const byte barStat = 10;
    /// <summary>
    /// 코루틴 대기 시간
    /// </summary>
    internal const float waitingTime = 0.1f;
    /// <summary>
    /// int 최대값
    /// </summary>
    internal const int maxInt = 2147483647;
}