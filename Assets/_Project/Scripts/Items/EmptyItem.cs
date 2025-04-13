using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Empty")]
public class EmptyItem : ItemData
{
    private void OnEnable()
    {
        itemType = ItemType.Empty;
        amount = 1;
    }
}