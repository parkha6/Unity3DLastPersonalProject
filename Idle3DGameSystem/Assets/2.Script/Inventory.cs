using UnityEngine;

/// <summary>
/// 인벤토리 관련 클래스
/// </summary>
public class Inventory : MonoBehaviour
{
    /// <summary>
    /// 인벤토리 표시
    /// </summary>
    void SetActive()
    { this.gameObject.SetActive(true); }
    /// <summary>
    /// 인벤토리 비표시
    /// </summary>
    void SetDeActive()
    { this.gameObject.SetActive(false); }
    /// <summary>
    /// 장착 아이템
    /// </summary>
    void EquipItems()
    { }
    /// <summary>
    /// 보유 아이템
    /// </summary>
    void HoldingItems()
    { }
}

class Stage
{
    /// <summary>
    /// 현재 스테이지
    /// </summary>
    int currentStage = 1;
    /// <summary>
    /// currentStage보다 스테이지 1상승
    /// </summary>
    int IncreaseStage()
    { return ++currentStage; }
}
class Gold
{
    /// <summary>
    /// 보유 골드
    /// </summary>
    int gold = 0;
    /// <summary>
    /// plusGold만큼 골드 값 증가.
    /// </summary>
    /// <param name="plusGold"></param>
    /// <returns></returns>
    int IncreaseGold(int plusGold)
    { return gold += plusGold; }
    /// <summary>
    /// minusGold만큼 골드 값 감소
    /// </summary>
    /// <param name="minusGold"></param>
    /// <returns></returns>
    int DecreaseGold(int minusGold)
    { return gold -= minusGold; }
}
/// <summary>
/// 몬스터 리스트 관련 클래스
/// </summary>
class MonsterParty
{
    /// <summary>
    /// 파티안의 몬스터 수를 지정
    /// </summary>
    void ChooseAmount()
    { }
    /// <summary>
    /// 모두 죽었는지 체크
    /// </summary>
    void CheckAllDead()
    { }
}
