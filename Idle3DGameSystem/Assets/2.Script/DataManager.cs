using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

/// <summary>
/// 플레이어 데이터 처리용 매니저
/// </summary>
public class DataManager : MonoSingleton<DataManager>
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
    /// 플레이어 이름 입력값을 돌려줌
    /// </summary>
    internal string InputPlayerName()
    { return UiMan.inputName.text; }
    /// <summary>
    /// 플레이어 데이터 불러오기
    /// </summary>
    void LoadPlayerData()
    { }
    /// <summary>
    /// 플레이어 데이터 저장하기
    /// </summary>
    void SavePlayerData()
    { }
    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = GetComponent<UiManager>();
            if (uiManager == null)
            { uiManager = gameObject.AddComponent<UiManager>(); }
        }
    }
}
