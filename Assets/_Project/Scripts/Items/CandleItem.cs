using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Candle")]
public class CandleItem : ItemData
{
    public bool IsLit;

    private void OnEnable()
    {
        itemType = ItemType.Candle;
        IsLit = false;
        amount = 0;
    }
    
    private void OnDisable()
    {
        IsLit = false;
    }
    
}