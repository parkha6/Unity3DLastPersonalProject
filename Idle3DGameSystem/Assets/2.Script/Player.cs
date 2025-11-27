using UnityEngine;
/// <summary>
/// 플레이어 클래스
/// </summary>
internal class Player : BattleUnit
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
    /// 총 경험치
    /// </summary>
    int exp = Consts.minValue;
    /// <summary>
    /// 총 경험치 프로퍼티
    /// </summary>
    internal int Exp { get { return exp; } }
    /// <summary>
    /// 현재 경험치
    /// </summary>
    int currentExp = Consts.none;
    /// <summary>
    /// 현재 경험치 프로퍼티
    /// </summary>
    internal int CurrentExp
    {
        get { return currentExp; }
        private set
        {
            if (value <= Consts.none)
            { value = Consts.none; }
            currentExp = value;
        }
    }
    /// <summary>
    /// 경험치 초기화
    /// </summary>
    /// <returns></returns>
    int ResetExp()
    { return CurrentExp = Consts.none; }
    /// <summary>
    /// plusExp만큼 경험치를 증가시킴.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    internal int IncreaseExp(int plusExp)
    { return CurrentExp += plusExp; }
    /// <summary>
    /// plusExp만큼 총 경험치 증가.
    /// </summary>
    /// <param name="plusExp"></param>
    /// <returns></returns>
    int IncreaseWholeExp(int plusExp)
    { return exp += plusExp; }
    /// <summary>
    /// plusHp만큼 총 체력 증가.
    /// </summary>
    /// <param name="plusHp"></param>
    /// <returns></returns>
    int IncreaseWholeHp(int plusHp)
    { return hp += plusHp; }
    /// <summary>
    /// plusMp만큼 총 마력 증가.
    /// </summary>
    /// <param name="plusMp"></param>
    /// <returns></returns>
    int IncreaseWholeMp(int plusMp)
    { return mp += plusMp; }
    internal void InputName(string inputName)
    { nameIs = inputName; }
}