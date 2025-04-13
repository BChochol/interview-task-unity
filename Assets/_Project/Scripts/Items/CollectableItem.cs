using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Collectable")]
public class CollectableItem : ItemData
{
    private void OnEnable()
    {
        itemType = ItemType.Collectable;
        amount = 0;
    }
}