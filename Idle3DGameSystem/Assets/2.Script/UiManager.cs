using UnityEngine;
/// <summary>
/// UI정보창 처리용 매니저
/// </summary>
public class UiManager : MonoSingleton<UiManager>
{
    /// <summary>
    /// 사용자 정보 UI창
    /// </summary>
    [Tooltip("사용자 정보 UI창")]
    [SerializeField]
    GameObject playerInfoUi;
    /// <summary>
    /// 플레이어 정보창 켜기
    /// </summary>
    void PlayerInfo()
    { playerInfoUi.SetActive(true); }
    /// <summary>
    /// 플레이어 정보창 끄기
    /// </summary>
    void OffPlayerInfo()
    { playerInfoUi.SetActive(false); }
}
