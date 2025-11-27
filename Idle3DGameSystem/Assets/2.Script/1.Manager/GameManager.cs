using System.Collections;
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
    /// 플레이어 클래스 변수
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
    /// <summary>
    /// 스테이지 클래스 변수 
    /// </summary>
    [SerializeField] private Stage stage;
    /// <summary>
    /// 스테이지 읽기 전용
    /// </summary>
    internal Stage Stage { get { return stage; } }
    /// <summary>
    /// 몬스터 리스트 클래스 변수
    /// </summary>
    [SerializeField] private MonsterList monsterList;
    /// <summary>
    /// 게임 시작 시점
    /// </summary>
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
    { UiMan.TypeNameUI(true); }
    /// <summary>
    /// 이름값을 세팅하면 이름 UI가 꺼짐
    /// </summary>
    internal void EnterName()
    {
        User.InputName(DataMan.InputPlayerName());
        UiMan.TypeNameUI(false);
        User.InitialStatSetting();
        InitialUISetting();
        StartBattle();
    }
    /// <summary>
    /// 초기 UI세팅
    /// </summary>
    void InitialUISetting()
    {
        DrawPlayerUI();
        UiMan.UserUI(true);
        UiMan.StageUI(true);
    }
    /// <summary>
    /// 플레이어의 정보를 UI에 표시한다.
    /// </summary>
    void DrawPlayerUI()
    {
        UiMan.SetAllInfo(User);
        UiMan.StageText(stage.MainStage, stage.SubStage);
    }
    /// <summary>
    /// 배틀 시작 함수
    /// </summary>
    void StartBattle()
    {
        monsterList.StartBattle();
        StartCoroutine(AutoBattle());
    }
    /// <summary>
    /// 자동 배틀 함수
    /// </summary>
    /// <returns></returns>
    IEnumerator AutoBattle()
    {
        while (!monsterList.CheckAllDead())
        {
            PlayerTurn();
            yield return new WaitForSeconds(Consts.waitingTime);
            bool check = MonsterTurn();
            Debug.Log(check);
            if (check)
            {
                yield return StartCoroutine(Resting());
                User.StartAgain();
            }
            yield return new WaitForSeconds(Consts.waitingTime);
        }
        if (monsterList.CheckAllDead())
        {
            stage.IncreaseStage();
            UiMan.StageText(stage.MainStage, stage.SubStage);
            StartBattle();
        }
    }
    /// <summary>
    /// 플레이어 턴에 몬스터를 팬다.
    /// </summary>
    void PlayerTurn()
    {
        //몬스터를 지정
        byte monAmount = monsterList.ReturnAmount();
        Monster targetMon = monsterList.TakeMonster(Consts.firstMon);
        byte hitWho = (byte)Random.Range(0, monAmount);
        if (monAmount == Consts.twoMon)
        {
            if (hitWho == Consts.secondMon || (hitWho == Consts.firstMon && targetMon.IsDead))
            {
                hitWho = Consts.secondMon;
                targetMon = monsterList.TakeMonster(hitWho);
                if (hitWho == Consts.secondMon && targetMon.IsDead)
                {
                    hitWho = Consts.firstMon;
                    targetMon = monsterList.TakeMonster(hitWho);
                }
            }
        }
        //공격
        targetMon.GetAttacked(User.Attack());
        Debug.Log($"몬스터 남은 체력{targetMon.CurrentHp}");
        Debug.Log($"monAmount값{monAmount}");
        //결과를 UI에 갱신
        if (monAmount == Consts.minValue)
        { UiMan.MonsterLeftHp(targetMon.CurrentHp, targetMon.Hp); }
        else if (monAmount == Consts.twoMon)
        {
            if (hitWho == Consts.firstMon)
            {
                Debug.Log($"Hit Who 0 {hitWho}");
                UiMan.MonsterLeftHp(targetMon.CurrentHp, targetMon.Hp);
            }
            else if (hitWho == Consts.secondMon)
            {
                Debug.Log($"Hit Who 1 {hitWho}");
                UiMan.MonsterRightHp(targetMon.CurrentHp, targetMon.Hp);
            }
        }
        //죽음체크
        if (targetMon.IsDead)
        { targetMon.DropReward(player); }
    }
    /// <summary>
    /// 몬스터 턴
    /// </summary>
    bool MonsterTurn()
    { return monsterList.AllAttack(User); }
    /// <summary>
    /// 죽었을때 패널티를 만드려고 넣은 함수
    /// </summary>
    IEnumerator Resting()
    {
        bool isStart = true;
        while (isStart)
        {
            UiManager.Instance.SetMessageUi(true);
            UiManager.Instance.SetCountdown(3);
            yield return new WaitForSeconds(Consts.minValue);
            UiManager.Instance.SetCountdown(2);
            yield return new WaitForSeconds(Consts.minValue);
            UiManager.Instance.SetCountdown(1);
            yield return new WaitForSeconds(Consts.minValue);
            UiManager.Instance.SetMessageUi(false);
            isStart = false;
        }
    }

    /// <summary>
    /// 게임 종료
    /// </summary>
    internal void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else  
        Application.Quit();
#endif
    }
}
