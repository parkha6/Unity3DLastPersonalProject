using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 분기 처리용 매니저
/// </summary>
public class GameManager : MonoSingleton<GameManager>
{
    /// <summary>
    /// UI매니저 넣는 변수
    /// </summary>
    private UiManager uiManager;
    /// <summary>
    /// UI매니저가 없을시 넣는 프로퍼티
    /// </summary>
    public UiManager UiMan
    {
        get
        {
            if (uiManager == null)
            {
                uiManager = GetComponent<UiManager>();
                if (uiManager == null)
                { uiManager = gameObject.AddComponent<UiManager>(); }
            }
            return uiManager;
        }
    }
    /// <summary>
    /// 데이터 매니저 넣는 변수
    /// </summary>
    private DataManager dataManager;
    /// <summary>
    /// 데이터 매니저가 없을시 넣는 프로퍼티
    /// </summary>
    public DataManager DataMan
    {
        get
        {
            if (dataManager == null)
            {
                dataManager = GetComponent<DataManager>();
                if (dataManager == null)
                { dataManager = gameObject.AddComponent<DataManager>(); }
            }
            return dataManager;
        }
    }
    private Player player;
    internal Player User
    {
        get
        {
            player = GetComponent<Player>();
            if (player == null)
            { player = gameObject.AddComponent<Player>(); }
            return player;
        }
    }
    private void Start()
    {
        StartGame();
    }

    /// <summary>
    /// 게임 시작
    /// </summary>
    internal void StartGame()
    { SetName();}
    private void SetName()
    {
        Debug.Log("UI켜짐");
        UiMan.TypeNameUI(true);
    }
    /// <summary>
    /// 이름값을 세팅함.
    /// </summary>
    internal void EnterName()
    {
        Debug.Log("이름 입력");
        User.nameIs = DataMan.InputPlayerName(User.nameIs);
        Debug.Log("UI꺼짐");
        UiMan.TypeNameUI(false);
    }
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
