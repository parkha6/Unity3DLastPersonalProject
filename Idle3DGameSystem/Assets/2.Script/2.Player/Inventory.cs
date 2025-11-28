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
