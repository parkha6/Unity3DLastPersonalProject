using System.IO;
using UnityEngine;

/// <summary>
/// 플레이어 데이터 처리용 매니저
/// </summary>
public class DataManager : MonoSingleton<DataManager>
{
    /// <summary>
    /// 저장 클래스
    /// </summary>
    SaveData saveData = new SaveData();
    /// <summary>
    /// 직렬화용 문자열
    /// </summary>
    string json;
    /// <summary>
    /// 저장경로
    /// </summary>
    string path;
    private void Awake()
    { path = Application.persistentDataPath + "/save.Json"; }
    /// <summary>
    /// 플레이어 이름 입력값을 돌려줌
    /// </summary>
    internal string InputPlayerName()
    { return UiManager.Instance.inputName.text; }
    /// <summary>
    /// 플레이어 데이터 불러오기
    /// </summary>
    internal bool LoadPlayerData()
    {
        if (File.Exists(path))
        {
            json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
            GameManager.Instance.User.nameIs = saveData.nameIs;
            GameManager.Instance.User.Level = saveData.level;
            GameManager.Instance.User.Atk = saveData.atk;
            GameManager.Instance.User.Def = saveData.def;
            GameManager.Instance.User.Hp = saveData.hp;
            GameManager.Instance.User.Mp = saveData.mp;
            GameManager.Instance.User.LoadPrivateBarData(saveData.currentHp, saveData.currentMp);
            GameManager.Instance.User.LoadValue(saveData.currentExp, saveData.exp, saveData.statPoint);
            if (GameManager.Instance.User.StatPoint >= Consts.minValue)
                UiManager.Instance.SetUpButton(true);
            GameManager.Instance.User.Gold = saveData.gold;
            GameManager.Instance.Stage.LoadStage(saveData.mainStage, saveData.subStage);
            return true;
        }
        return false;
    }
    /// <summary>
    /// 플레이어 데이터 저장하기
    /// </summary>
    internal void SavePlayerData()
    {
        SaveData saveData = new SaveData();
        saveData.nameIs = GameManager.Instance.User.nameIs;
        saveData.level = GameManager.Instance.User.Level;
        saveData.atk = GameManager.Instance.User.Atk;
        saveData.def = GameManager.Instance.User.Def;
        saveData.hp = GameManager.Instance.User.Hp;
        saveData.currentHp = GameManager.Instance.User.CurrentHp;
        saveData.mp = GameManager.Instance.User.Mp;
        saveData.currentMp = GameManager.Instance.User.CurrentMp;
        saveData.exp = GameManager.Instance.User.Exp;
        saveData.currentExp = GameManager.Instance.User.CurrentExp;
        saveData.statPoint = GameManager.Instance.User.StatPoint;
        saveData.gold = GameManager.Instance.User.Gold;
        saveData.mainStage = GameManager.Instance.Stage.MainStage;
        saveData.subStage = GameManager.Instance.Stage.SubStage;
        json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }
}
/// <summary>
/// 데이터 저장용 클래스
/// </summary>
[System.Serializable]
public class SaveData
{
    /// <summary>
    /// 이름 변수
    /// </summary>
    public string nameIs;
    /// <summary>
    /// 레벨 변수
    /// </summary>
    public byte level;
    /// <summary>
    /// 공격력 변수
    /// </summary>
    public int atk;
    /// <summary>
    /// 방어력 변수
    /// </summary>
    public int def;
    /// <summary>
    /// 총 체력
    /// </summary>
    public int hp;
    /// <summary>
    /// 현재 체력
    /// </summary>
    public int currentHp;
    /// <summary>
    /// 총 마력
    /// </summary>
    public int mp;
    /// <summary>
    /// 현재 마력
    /// </summary>
    public int currentMp;
    /// <summary>
    /// 총 경험치
    /// </summary>
    public int exp;
    /// <summary>
    /// 현재 경험치
    /// </summary>
    public int currentExp;
    /// <summary>
    /// 스텟포인트
    /// </summary>
    public int statPoint;
    /// <summary>
    /// 가지고 있는 골드 수치
    /// </summary>
    public int gold;
    /// <summary>
    /// 메인 스테이지
    /// </summary>
    public int mainStage;
    /// <summary>
    /// 서브 스테이지
    /// </summary>
    public int subStage;
}