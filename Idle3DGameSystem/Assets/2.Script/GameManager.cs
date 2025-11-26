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
    /// <summary>
    /// 플레이어 변수
    /// </summary>
    [SerializeField] private Player player;
    /// <summary>
    /// 플레이어 프로퍼티
    /// </summary>
    internal Player User
    {
        get
        {
            if (player != null)
            {
                player = GetComponent<Player>();
                if (player == null)
                { player = gameObject.AddComponent<Player>(); }
            }
            return player;
        }
    }
    private void Start()
    { StartGame(); }

    /// <summary>
    /// 게임 시작
    /// </summary>
    internal void StartGame()
    { SetName(); }
    /// <summary>
    /// 이름입력을 위한 세팅 함수
    /// </summary>
    private void SetName()
    {
        if (uiManager != null)
            UiMan.TypeNameUI(true);
        else
            Debug.Log("UI매니저 없음");
    }
    /// <summary>
    /// 이름값을 세팅하면 이름 UI가 꺼짐
    /// </summary>
    internal void EnterName()
    {
        if (player != null && dataManager != null)
            User.InputName(DataMan.InputPlayerName());
        else if (player == null)
            Debug.Log("플레이어 없음");
        else if (dataManager == null)
            Debug.Log("데이터 매니저 없음");
        else
            Debug.Log("플레이어와 데이터 매니저 둘다 없음.");
        if (uiManager != null)
        {
            UiMan.TypeNameUI(false);
            if (player != null)
                DrawPlayerUI();
            else
                Debug.Log("플레이어 없음");
            UiMan.UserUI(true);
        }
        else
            Debug.Log("UI매니저 없음");

    }
    /// <summary>
    /// 플레이어의 정보를 UI에 표시한다.
    /// </summary>
    void DrawPlayerUI()
    {
        UiMan.NameText(User.nameIs);
        UiMan.LevelText(User.Level);
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

    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = GetComponent<UiManager>();
            if (uiManager == null)
            { uiManager = gameObject.AddComponent<UiManager>(); }
        }
        if (dataManager == null)
        {
            dataManager = GetComponent<DataManager>();
            if (dataManager == null)
            { dataManager = gameObject.AddComponent<DataManager>(); }
        }
        if (player != null)
        {
            player = GetComponent<Player>();
            if (player == null)
            { player = gameObject.AddComponent<Player>(); }
        }
    }
}
