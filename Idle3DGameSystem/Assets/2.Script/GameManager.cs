using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 분기 처리용 매니저
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    /// <summary>
    /// 게임 시작
    /// </summary>
    void StartGame()
    { }
    /// <summary>
    /// 플레이어 턴
    /// </summary>
    void PlayerTurn()
    { }
    /// <summary>
    /// 몬스터 턴
    /// </summary>
    void MonsterTurn()
    { }
    /// <summary>
    /// 게임 종료
    /// </summary>
    void QuitGame()
    { }
}
