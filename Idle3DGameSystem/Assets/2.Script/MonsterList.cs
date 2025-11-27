using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 몬스터 리스트 관련 클래스
/// </summary>
public class MonsterList : MonoBehaviour
{
    /// <summary>
    /// 몬스터 배열
    /// </summary>
    List<Monster> monsters = new List<Monster>();
    /// <summary>
    /// 몬스터 이름 데이터
    /// </summary>
    string[] names = new string[] { "그냥 상자", "멍 때리는 상자", "아무튼 상자", "당황한 상자", "무거운 상자" };

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
        byte result = (byte)Random.Range(0, 1);
        if (result == 0)
        { UiManager.Instance.MonsterSet(true); }
        else if (result == 1)
        { UiManager.Instance.MonsterSet(false); }
        return result;
    }
    /// <summary>
    /// 지정된 숫자만큼  몬스터가 없으면 새로 생성한다.
    /// </summary>
    /// <param name="num"></param>
    void SetMonster(byte num)
    {
        for (int i = Consts.none; i < num; ++i)
        {
            if (monsters[num] == null)
            {
                monsters.Add(monsters[num]);
                ChooseRandomInfo(monsters[num]);
                if (num == 0)
                { UiManager.Instance.MonsterLeftInfo(monsters[num]); }
                else if (num == 1)
                { UiManager.Instance.MonsterRightInfo(monsters[num]); }
            }
        }
    }
    /// <summary>
    /// 몬스터 정보 세팅용
    /// </summary>
    /// <param name="targetMon"></param>
    void ChooseRandomInfo(Monster targetMon)
    {
        SetName(targetMon.nameIs);
        SetLevel(targetMon.Level);
        SetStat(targetMon, targetMon.Atk);
        SetStat(targetMon, targetMon.Def);
        SetHp(targetMon);
        SetMp(targetMon);
        SetLargeStat(targetMon, targetMon.DropExp);
        SetLargeStat(targetMon, targetMon.Gold);
    }
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
        targetMon.CurrentHp = targetMon.Hp;
        return targetMon.Hp;
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
        targetMon.CurrentMp = targetMon.Mp;
        return targetMon.Mp;
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
    /// <summary>
    /// 몬스터가 모두 죽었는지 체크하고 모두 죽었으면 리스트를 비움.
    /// </summary>
    bool CheckAllDead()
    {
        bool result = monsters.All<Monster>(monster => monster.IsDead == true);
        if (result)
        { monsters.Clear(); }
        return result;
    }
}
