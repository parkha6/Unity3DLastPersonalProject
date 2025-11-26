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
    /// <summary>
    /// 사용자 정보 UI창
    /// </summary>
    [Tooltip("사용자 정보 UI창")]
    [SerializeField] GameObject playerInfoUi;
    /// <summary>
    /// 이름 입력창 활성&비활성
    /// </summary>
    /// <param name="isSet"></param>
    internal void TypeNameUI(bool isSet)
    { typeNameUI.SetActive(isSet); }
    /// <summary>
    /// 플레이어 정보창 활성&비활성
    /// </summary>
    void PlayerInfo(bool isSet)
    { playerInfoUi.SetActive(isSet); }
    private void Awake()
    { enterName.onClick.AddListener(GameMan.EnterName); }
}
