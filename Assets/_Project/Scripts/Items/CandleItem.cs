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
    
    private void OnDisable()
    {
        amount = 0;
        IsLit = false;
    }
    
    public void Light()
    {
        IsLit = true;
    }
}