using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 몬스터 리스트 관련 클래스
/// </summary>
public class MonsterList : MonoBehaviour
{
    /// <summary>
    /// 왼쪽 박스 프리팹
    /// </summary>
    [SerializeField] GameObject leftBox;
    /// <summary>
    /// 중앙 박스 프리팹
    /// </summary>
    [SerializeField] GameObject middleBox;
    /// <summary>
    /// 오른쪽 박스 프리팹
    /// </summary>
    [SerializeField] GameObject rightBox;
    /// <summary>
    /// 몬스터 배열
    /// </summary>
    List<Monster> monsters = new List<Monster>();
    /// <summary>
    /// 몬스터 이름 데이터
    /// </summary>
    string[] names = new string[] { "그냥 상자", "멍 때리는 상자", "아무튼 상자", "당황한 상자", "무거운 상자", "가벼운 상자" };
    internal void StartBattle()
    {
        byte amount = ChooseAmount();
        SetMonster(amount);
    }
    /// <summary>
    /// 파티안의 몬스터 수를 지정
    /// </summary>
    byte ChooseAmount()
    {
        byte result = (byte)Random.Range(1, 3);
        if (result == 1)
        { UiManager.Instance.MonsterSet(true); }
        else if (result == 2)
        { UiManager.Instance.MonsterSet(false); }
        return result;
    }
    /// <summary>
    /// 지정된 숫자만큼  몬스터가 없으면 새로 생성한다.
    /// </summary>
    /// <param name="num"></param>
    void SetMonster(byte num)
    {
        Debug.Log("몬스터 세팅");
        if (monsters.Count < num)
        {
            for (int i = Consts.minValue; i <= num; ++i)
            {
                GameObject boxPrefab = middleBox;
                if (num == 1 && i == 1)
                { boxPrefab = middleBox; }
                else if (num == 2 && i == 1)
                { boxPrefab = leftBox; }
                else if (num == 2 && i == 2)
                { boxPrefab = rightBox; }
                GameObject newBox = Instantiate(boxPrefab);
                Monster newMon = newBox.GetComponent<Monster>();
                ChooseRandomInfo(newMon);
                monsters.Add(newMon);
                if (i == 1)
                { UiManager.Instance.MonsterLeftInfo(newMon); }
                else if (i == 2)
                { UiManager.Instance.MonsterRightInfo(newMon); }
            }
        }
    }
    /// <summary>
    /// 몬스터 정보 세팅용
    /// </summary>
    /// <param name="targetMon"></param>
    void ChooseRandomInfo(Monster targetMon)
    {
        targetMon.nameIs = SetName(targetMon.nameIs);
        Debug.Log(targetMon.nameIs);
        targetMon.Level = SetLevel(targetMon.Level);
        targetMon.Atk = SetStat(targetMon, targetMon.Atk);
        targetMon.Def = SetLowStat(targetMon, targetMon.Def);
        Debug.Log(targetMon.Def);
        targetMon.Hp = SetHp(targetMon);
        targetMon.Mp = SetMp(targetMon);
        targetMon.DropExp = SetLargeStat(targetMon, targetMon.DropExp);
        targetMon.IncreaseGold(SetLargeStat(targetMon, targetMon.Gold));
    }
    /// <summary>
    /// 외부에서 몬스터 수 가져가는 함수
    /// </summary>
    /// <returns></returns>
    internal byte ReturnAmount()
    { return (byte)monsters.Count; }
    /// <summary>
    /// 특정번호의 몬스터를 돌려줌
    /// </summary>
    /// <param name="monNum"></param>
    /// <returns></returns>
    internal Monster TakeMonster(byte monNum)
    { return monsters[monNum]; }

    /// <summary>
    /// 몬스터 이름 세팅 함수
    /// </summary>
    /// <param name="targetName"></param>
    /// <returns></returns>
    string SetName(string targetName)
    { return targetName = names[Random.Range(0, names.Length - 1)]; }
    /// <summary>
    /// 몬스터 레벨 세팅 함수
    /// </summary>
    /// <param name="targetLevel"></param>
    /// <returns></returns>
    byte SetLevel(byte targetLevel)
    {
        int currentStage = GameManager.Instance.Stage.MainStage;
        if (currentStage > Consts.maxLevel)
        { currentStage = Consts.maxLevel; }
        return targetLevel = (byte)(Random.Range(Consts.minValue, currentStage));
    }
    /// <summary>
    /// 몬스터 체력 세팅 함수
    /// </summary>
    /// <param name="targetMon"></param>
    /// <returns></returns>
    int SetHp(Monster targetMon)
    {
        int currentTier = GameManager.Instance.Stage.SubStage;
        targetMon.Hp = Random.Range(Consts.minValue, currentTier) * targetMon.Level;
        return targetMon.Hp * Consts.barStat;
    }
    /// <summary>
    /// 몬스터 마력 세팅 함수
    /// </summary>
    /// <param name="targetMon"></param>
    /// <returns></returns>
    int SetMp(Monster targetMon)
    {
        int currentTier = GameManager.Instance.Stage.SubStage;
        targetMon.Mp = Random.Range(Consts.minValue, currentTier) * targetMon.Level;
        return targetMon.Mp * Consts.barStat;
    }
    /// <summary>
    /// 스텟을 넣으면 레벨에 맞춰 랜덤 배치함.
    /// </summary>
    /// <param name="targetMon"></param>
    /// <param name="targetStat"></param>
    /// <returns></returns>
    int SetStat(Monster targetMon, int targetStat)
    { return targetStat = Random.Range(Consts.minValue, targetMon.Level); }
    /// <summary>
    /// 스텟을 넣으면 0부터 레벨까지 랜덤배치함.
    /// </summary>
    /// <param name="targetMon"></param>
    /// <param name="targetStat"></param>
    /// <returns></returns>
    int SetLowStat(Monster targetMon, int targetStat)
    { return targetStat = Random.Range(Consts.none, targetMon.Level - Consts.minValue); }
    /// <summary>
    /// 스텟을 넣으면 현재 스테이지까지 고려해서 랜덤 배치함.
    /// </summary>
    /// <param name="targetMon"></param>
    /// <param name="targetStat"></param>
    /// <returns></returns>
    int SetLargeStat(Monster targetMon, int targetStat)
    {
        int currentTier = GameManager.Instance.Stage.SubStage;
        return targetStat = Random.Range(Consts.none, currentTier) * targetMon.Level;
    }
    internal bool AllAttack(Player player)
    {
        foreach (Monster mon in monsters)
        {
            player.GetAttacked(mon.Attack());
            if (player.IsDead)
            { return true; }
        }
        return false;
    }
    /// <summary>
    /// 몬스터가 모두 죽었는지 체크하고 모두 죽었으면 리스트를 비움.
    /// </summary>
    internal bool CheckAllDead()
    {
        bool result = monsters.All<Monster>(monster => monster.IsDead == true);
        if (result)
        {
            foreach (Monster mon in monsters)
            {
                if (mon != null && mon.gameObject != null)
                { Destroy(mon.gameObject); }
            }
            monsters.Clear();
        }
        return result;
    }
}
