using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Empty")]
public class EmptyItem : ItemData
{
    private void OnEnable()
    {
        itemType = ItemType.Collectable;
        amount = 1;
    }
}