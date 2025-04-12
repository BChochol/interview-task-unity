using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Candle")]
public class CandleItem : ItemData
{
    public bool isLit;

    private void OnEnable()
    {
        itemType = ItemType.Candle;
        isLit = false;
    }

    public void LightCandle()
    {
        isLit = true;
    }
}