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
    /// <summary>
    /// 사용자 정보 UI창
    /// </summary>
    [Tooltip("사용자 정보 UI창")]
    [SerializeField] GameObject playerInfoUi;
    /// <summary>
    /// 이름 입력창 활성 & 비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void TypeNameUI(bool isSet)
    { typeNameUI.SetActive(isSet); }
    /// <summary>
    /// 플레이어 인게임 UI 활성 & 비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void UserUI(bool isSet)
    { userUi.SetActive(isSet);}
    /// <summary>
    /// inputName을 입력하면 플레이어 이름 텍스트에 표시함.
    /// </summary>
    /// <param name="inputName"></param>
    /// <returns></returns>
    internal string NameText(string inputName)
    { return userName.text = inputName; }
    /// <summary>
    /// inputLevel에 입력한 바이트값을 플레이어 레벨 텍스트에 표시함.
    /// </summary>
    /// <param name="inputLevel"></param>
    /// <returns></returns>
    internal string LevelText(byte inputLevel)
    { return userLevel.text = inputLevel.ToString(); }
    /// <summary>
    /// 플레이어 정보창 활성&비활성
    /// </summary>
    void PlayerInfo(bool isSet)
    { playerInfoUi.SetActive(isSet); }
    private void Awake()
    { enterName.onClick.AddListener(GameMan.EnterName); }
}
