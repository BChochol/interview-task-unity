using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Candle")]
public class CandleItem : ItemData
{
    private bool IsLit;

    private void OnEnable()
    {
        itemType = ItemType.Candle;
        IsLit = false;
    }
}