using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI정보창 처리용 매니저
/// </summary>
public class UiManager : MonoSingleton<UiManager>
{
    /// <summary>
    /// 게임 매니저 넣는 변수
    /// </summary>
    private GameManager gameManager;
    /// <summary>
    /// 게임 매니저가 없을시 넣는 프로퍼티
    /// </summary>
    public GameManager GameMan
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GetComponent<GameManager>();
                if (gameManager == null)
                { gameManager = gameObject.AddComponent<GameManager>(); }
            }
            return gameManager;
        }
    }
    [Header("이름 입력 UI")]
    /// <summary>
    /// 이름 입력 UI창
    /// </summary>
    [Tooltip("이름 입력 UI창")]
    [SerializeField] GameObject typeNameUI;
    /// <summary>
    /// 처음에 이름을 입력하는 칸
    /// </summary>
    [Tooltip("처음에 이름을 입력하는 칸")]
    [SerializeField] internal TMP_InputField inputName;
    /// <summary>
    /// 입력 완료 버튼
    /// </summary>
    [Tooltip("입력완료 버튼")]
    [SerializeField] internal Button enterName;
    [Header("인게임 플레이어 UI")]
    /// <summary>
    /// 플레이어 UI
    /// </summary>
    [Tooltip("플레이어 UI")]
    [SerializeField] GameObject userUi;
    /// <summary>
    /// 플레이어 이름 텍스트
    /// </summary>
    [Tooltip("플레이어 이름 텍스트")]
    [SerializeField] internal TMP_Text userName;
    /// <summary>
    /// 플레이어 레벨 텍스트
    /// </summary>
    [Tooltip("플레이어 레벨 텍스트")]
    [SerializeField] TMP_Text userLevel;
    /// <summary>
    /// 플레이어 Hp 텍스트
    /// </summary>
    [Tooltip("플레이어 Hp 텍스트")]
    [SerializeField] TMP_Text userHp;
    /// <summary>
    /// 플레이어 Hp바 이미지
    /// </summary>
    [Tooltip("플레이어 Hp바 이미지")]
    [SerializeField] Image userHpBar;
    /// <summary>
    /// 플레이어 Mp 텍스트
    /// </summary>
    [Tooltip("플레이어 Mp 텍스트")]
    [SerializeField] TMP_Text userMp;
    /// <summary>
    /// 플레이어 Mp바 이미지
    /// </summary>
    [Tooltip("플레이어 Mp바 이미지")]
    [SerializeField] Image userMpBar;
    /// <summary>
    /// 플레이어 경험치 텍스트
    /// </summary>
    [Tooltip("플레이어 경험치 텍스트")]
    [SerializeField] TMP_Text userExp;
    /// <summary>
    /// 플레이어 경험치 바 이미지
    /// </summary>
    [Tooltip("플레이어 경험치 바 이미지")]
    [SerializeField] Image userExpBar;
    [Header("스테이지 UI")]
    /// <summary>
    /// 스테이지 UI
    /// </summary>
    [Tooltip("스테이지 UI")]
    [SerializeField] GameObject stageUi;
    /// <summary>
    /// 스테이지 표시 텍스트
    /// </summary>
    [Tooltip("스테이지 표시 텍스트")]
    [SerializeField] TMP_Text stageText;
    [Header("사용자 정보 UI")]
    /// <summary>
    /// 사용자 정보 UI 띄우는 버튼
    /// </summary>
    [Tooltip("사용자 정보 UI 띄우는 버튼")]
    [SerializeField] Button infoButton;
    /// <summary>
    /// 사용자 정보 UI창
    /// </summary>
    [Tooltip("사용자 정보 UI창")]
    [SerializeField] GameObject playerInfoUi;
    /// <summary>
    /// 사용자 정보 이름 텍스트
    /// </summary>
    [Tooltip("사용자 정보 이름 텍스트")]
    [SerializeField] TMP_Text infoNameText;
    /// <summary>
    /// 사용자 정보 레벨 텍스트
    /// </summary>
    [Tooltip("사용자 정보 레벨 텍스트")]
    [SerializeField] TMP_Text infoLevelText;
    /// <summary>
    /// 사용자 정보 Hp 바
    /// </summary>
    [Tooltip("사용자 정보 Hp 바")]
    [SerializeField] Image infoHpBar;
    /// <summary>
    /// 사용자 정보 Hp 텍스트
    /// </summary>
    [Tooltip("사용자 정보 Hp 텍스트")]
    [SerializeField] TMP_Text infoHpText;
    /// <summary>
    /// 사용자 정보 Mp 바
    /// </summary>
    [Tooltip("사용자 정보 Mp 바")]
    [SerializeField] Image infoMpBar;
    /// <summary>
    /// 사용자 정보 Mp 텍스트
    /// </summary>
    [Tooltip("사용자 정보 Mp 텍스트")]
    [SerializeField] TMP_Text infoMpText;
    /// <summary>
    /// 사용자 정보 Exp 바
    /// </summary>
    [Tooltip("사용자 정보 Exp 바")]
    [SerializeField] Image infoExpBar;
    /// <summary>
    /// 사용자 정보 Exp 텍스트
    /// </summary>
    [Tooltip("사용자 정보 Exp 텍스트")]
    [SerializeField] TMP_Text infoExpText;
    /// <summary>
    /// 사용자 정보 공격력 텍스트
    /// </summary>
    [Tooltip("사용자 정보 공격력 텍스트")]
    [SerializeField] TMP_Text infoAtkText;
    /// <summary>
    /// 사용자 정보 방어력 텍스트
    /// </summary>
    [Tooltip("사용자 정보 방어력 텍스트")]
    [SerializeField] TMP_Text infoDefText;
    /// <summary>
    /// 사용자 정보 소지금 텍스트
    /// </summary>
    [Tooltip("사용자 정보 소지금 텍스트")]
    [SerializeField] TMP_Text infoGold;
    /// <summary>
    /// 사용자 정보 레벨업 포인트 텍스트
    /// </summary>
    [Tooltip("사용자 정보 레벨업 포인트 텍스트")]
    [SerializeField] TMP_Text infoPoint;
    /// <summary>
    /// 사용자 정보 UI 닫는 버튼
    /// </summary>
    [Tooltip("사용자 정보 UI 닫는 버튼")]
    [SerializeField] Button infoCloseButton;
    [Header("포인트 업 버튼")]
    /// <summary>
    /// 버튼 UI
    /// </summary>
    [Tooltip("버튼 UI")]
    [SerializeField] GameObject UpUi;
    /// <summary>
    /// Hp업 버튼
    /// </summary>
    [Tooltip("Hp업 버튼")]
    [SerializeField] Button hpUp;
    /// <summary>
    /// Mp업 버튼
    /// </summary>
    [Tooltip("Mp업 버튼")]
    [SerializeField] Button mpUp;
    /// <summary>
    /// Atk업 버튼
    /// </summary>
    [Tooltip("Atk업 버튼")]
    [SerializeField] Button atkUp;
    /// <summary>
    /// Def업 버튼
    /// </summary>
    [Tooltip("Def업 버튼")]
    [SerializeField] Button defUp;
    [Header("몬스터 표시 창")]
    /// <summary>
    /// 왼쪽 몬스터 이름창
    /// </summary>
    [Tooltip("왼쪽 몬스터 이름창")]
    [SerializeField] GameObject leftInfo;
    /// <summary>
    /// 왼쪽 몬스터 이름 텍스트
    /// </summary>
    [Tooltip("왼쪽 몬스터 이름 텍스트")]
    [SerializeField] TMP_Text leftName;
    /// <summary>
    /// 왼쪽 몬스터 레벨 텍스트
    /// </summary>
    [Tooltip("왼쪽 몬스터 레벨 텍스트")]
    [SerializeField] TMP_Text leftLevel;
    /// <summary>
    /// 오른쪽 몬스터 이름창
    /// </summary>
    [Tooltip("오른쪽 몬스터 이름창")]
    [SerializeField] GameObject rightInfo;
    /// <summary>
    /// 오른쪽 몬스터 이름 텍스트
    /// </summary>
    [Tooltip("오른쪽 몬스터 이름 텍스트")]
    [SerializeField] TMP_Text rightName;
    /// <summary>
    /// 오른쪽 몬스터 레벨 텍스트
    /// </summary>
    [Tooltip("오른쪽 몬스터 레벨 텍스트")]
    [SerializeField] TMP_Text rightLevel;
    /// <summary>
    /// 왼쪽 체력바
    /// </summary>
    [Tooltip("왼쪽 체력바")]
    [SerializeField] GameObject leftBar;
    /// <summary>
    /// 왼쪽 몬스터 HP바 이미지
    /// </summary>
    [Tooltip("왼쪽 몬스터 HP바 이미지")]
    [SerializeField] Image leftHpBar;
    /// <summary>
    /// 왼쪽 몬스터 HP 텍스트
    /// </summary>
    [Tooltip("왼쪽 몬스터 HP 텍스트")]
    [SerializeField] TMP_Text leftHpText;
    /// <summary>
    /// 왼쪽 몬스터 MP바 이미지
    /// </summary>
    [Tooltip("왼쪽 몬스터 HP바 이미지")]
    [SerializeField] Image leftMpBar;
    /// <summary>
    /// 왼쪽 몬스터 MP 텍스트
    /// </summary>
    [Tooltip("왼쪽 몬스터 MP 텍스트")]
    [SerializeField] TMP_Text leftMpText;

    /// <summary>
    /// 오른쪽 체력바
    /// </summary>
    [Tooltip("오른쪽 체력바")]
    [SerializeField] GameObject rightBar;
    /// <summary>
    /// 오른쪽 몬스터 HP바 이미지
    /// </summary>
    [Tooltip("오른쪽 몬스터 HP바 이미지")]
    [SerializeField] Image rightHpBar;
    /// <summary>
    /// 오른쪽 몬스터 HP 텍스트
    /// </summary>
    [Tooltip("오른쪽 몬스터 HP 텍스트")]
    [SerializeField] TMP_Text rightHpText;
    /// <summary>
    /// 오른쪽 몬스터 MP바 이미지
    /// </summary>
    [Tooltip("오른쪽 몬스터 HP바 이미지")]
    [SerializeField] Image rightMpBar;
    /// <summary>
    /// 오른쪽 몬스터 MP 텍스트
    /// </summary>
    [Tooltip("오른쪽 몬스터 MP 텍스트")]
    [SerializeField] TMP_Text rightMpText;

    /// <summary>
    /// 이름 입력창 활성 & 비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void TypeNameUI(bool isSet)
    {
        if (typeNameUI != null)
            typeNameUI.SetActive(isSet);
        else
            Debug.Log("이름 입력창 없음");
    }
    /// <summary>
    /// 플레이어 인게임 UI 활성 & 비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void UserUI(bool isSet)
    { userUi.SetActive(isSet); }
    /// <summary>
    /// player클래스를 입력하면 자동으로 데이터를 UI창에 띄움
    /// </summary>
    /// <param name="user"></param>
    internal void SetAllInfo(Player user)
    {
        NameText(user.nameIs);
        LevelText(user.Level);
        SetHp(user.CurrentHp, user.Hp);
        SetMp(user.CurrentMp, user.Mp);
        SetExp(user.CurrentExp, user.Exp);
        SetAtk(user.Atk);
        SetDef(user.Def);
        SetGold(user.Gold);
        SetPoint(user.StatPoint);
    }
    /// <summary>
    /// inputName을 입력하면 플레이어 이름 텍스트에 표시함.
    /// </summary>
    /// <param name="inputName"></param>
    /// <returns></returns>
    internal string NameText(string inputName)
    {
        userName.text = inputName;
        infoNameText.text = inputName;
        return userName.text;
    }
    /// <summary>
    /// inputLevel에 입력한 바이트값을 플레이어 레벨 텍스트에 표시함.
    /// </summary>
    /// <param name="inputLevel"></param>
    /// <returns></returns>
    internal string LevelText(byte inputLevel)
    {
        userLevel.text = $"레벨 {inputLevel.ToString()}";
        infoLevelText.text = $"레벨 {inputLevel.ToString()}";
        return userLevel.text;
    }
    /// <summary>
    /// 플레이어 Hp표시
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="hp"></param>

    internal string SetHp(int currentHp, int hp)
    {
        userHpBar.fillAmount = (float)currentHp / hp;
        infoHpBar.fillAmount = (float)currentHp / hp;
        infoHpText.text = $"{currentHp}/{hp}";
        return userHp.text = $"{currentHp}/{hp}";
    }
    /// <summary>
    /// 플레이어 Mp표시
    /// </summary>
    /// <param name="currentMp"></param>
    /// <param name="mp"></param>
    internal string SetMp(int currentMp, int mp)
    {
        userMpBar.fillAmount = (float)currentMp / (float)mp;
        infoMpBar.fillAmount = (float)currentMp / (float)mp;
        infoMpText.text = $"{currentMp}/{mp}";
        return userMp.text = $"{currentMp}/{mp}";
    }
    /// <summary>
    /// 플레이어 경험치 표시
    /// </summary>
    /// <param name="currentExp"></param>
    /// <param name="exp"></param>
    internal string SetExp(int currentExp, int exp)
    {
        userExpBar.fillAmount = (float)currentExp / (float)exp;
        infoExpBar.fillAmount = (float)currentExp / (float)exp;
        infoExpText.text = $"{currentExp}/{exp}";
        return userExp.text = $"{currentExp}/{exp}";
    }
    /// <summary>
    /// 플레이어 공격력 표시
    /// </summary>
    /// <param name="atk"></param>
    internal string SetAtk(int atk)
    { return infoAtkText.text = $"공격력 {atk}"; }
    /// <summary>
    /// 플레이어 방어력 표시
    /// </summary>
    /// <param name="def"></param>
    internal string SetDef(int def)
    { return infoDefText.text = $"방어력 {def}"; }
    internal string SetGold(int gold)
    { return infoGold.text = $"{gold}원"; }
    /// <summary>
    /// 정보창에 레벨업 포인트 띄워 줌
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    internal string SetPoint(int point)
    { return infoPoint.text = $"포인트 {point}"; }
    /// <summary>
    /// 스테이지 UI활성 & 비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void StageUI(bool isSet)
    { stageUi.SetActive(isSet); }
    /// <summary>
    /// 스테이지 mainStage - subStage로 스테이지 텍스트에 표시
    /// </summary>
    /// <param name="mainStage"></param>
    /// <param name="subStage"></param>
    /// <returns></returns>
    internal string StageText(int mainStage, int subStage)
    { return stageText.text = $"스테이지 {mainStage}-{subStage}"; }
    /// <summary>
    /// 플레이어 정보창 활성
    /// </summary>
    void PlayerInfoActive()
    { playerInfoUi.SetActive(true); }
    /// <summary>
    /// 플레이어 정보창 비활성
    /// </summary>
    void PlayerInfoDeactive()
    { playerInfoUi.SetActive(false); }
    /// <summary>
    /// 포인트 업 UI 활성화 & 비활성화
    /// </summary>
    internal void SetUpButton(bool isSet)
    { UpUi.SetActive(isSet); }
    /// <summary>
    /// 몬스터가 1명이냐 2명이냐에 따라 UI표시를 바꿈
    /// </summary>
    /// <param name="isOne"></param>
    internal void MonsterSet(bool isOne)
    {
        leftInfo.SetActive(true);
        rightInfo.SetActive(!isOne);
        leftBar.SetActive(true);
        rightBar.SetActive(!isOne);
    }
    /// <summary>
    /// 왼쪽 몬스터 정보창 띄우기
    /// </summary>
    internal void MonsterLeftInfo(Monster targetMon)
    {
        Debug.Log("왼쪽 정보창");
        leftName.text = targetMon.nameIs;
        leftLevel.text = $"레벨 {targetMon.Level}";
        leftHpBar.fillAmount = (float)targetMon.CurrentHp / (float)targetMon.Hp;
        leftHpText.text = $"{targetMon.CurrentHp}/{targetMon.Hp}";
        leftMpBar.fillAmount = (float)targetMon.CurrentMp / (float)targetMon.Mp;
        leftMpText.text = $"{targetMon.CurrentMp}/{targetMon.Mp}";
    }
    /// <summary>
    /// 왼쪽 상자 hp만 바꿈
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="hp"></param>
    /// <returns></returns>
    internal string MonsterLeftHp(int currentHp, int hp)
    {
        leftHpBar.fillAmount = (float)currentHp / (float)hp;
        return leftHpText.text = $"{currentHp}/{hp}";
    }
    /// <summary>
    /// 오른쪽 몬스터 정보창 띄우기
    /// </summary>
    internal void MonsterRightInfo(Monster targetMon)
    {
        Debug.Log("오른쪽 정보창");
        rightName.text = targetMon.nameIs;
        rightLevel.text = $"레벨 {targetMon.Level}";
        rightHpBar.fillAmount = (float)targetMon.CurrentHp / (float)targetMon.Hp;
        rightHpText.text = $"{targetMon.CurrentHp}/{targetMon.Hp}";
        rightMpBar.fillAmount = (float)targetMon.CurrentMp / (float)targetMon.Mp;
        rightMpText.text = $"{targetMon.CurrentMp}/{targetMon.Mp}";
    }
    /// <summary>
    /// 오른쪽 상자 hp만 바꿈
    /// </summary>
    /// <param name="currentHp"></param>
    /// <param name="hp"></param>
    /// <returns></returns>
    internal string MonsterRightHp(int currentHp, int hp)
    {
        rightHpBar.fillAmount = (float)currentHp / (float)hp;
        return rightHpText.text = $"{currentHp}/{hp}";
    }
    private void Start()
    {
        if (enterName != null)
            enterName.onClick.AddListener(GameMan.EnterName);
        else
            Debug.Log("입력버튼 없음");
        if (infoButton != null)
            infoButton.onClick.AddListener(PlayerInfoActive);
        else
            Debug.Log("인포버튼 없음");
        if (infoCloseButton != null)
            infoCloseButton.onClick.AddListener(PlayerInfoDeactive);
        else
            Debug.Log("인포 닫힘 버튼 없음");
        hpUp.onClick.AddListener(GameMan.User.SetHpUp);
        mpUp.onClick.AddListener(GameMan.User.SetMpUp);
        atkUp.onClick.AddListener(GameMan.User.SetAtkUp);
        defUp.onClick.AddListener(GameMan.User.SetDefUp);
    }
}
