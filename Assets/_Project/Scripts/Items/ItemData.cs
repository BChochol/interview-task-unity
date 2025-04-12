using UnityEngine;

public enum ItemType { Empty, Collectable, Candle }

public abstract class ItemData : ScriptableObject
{
    public ItemType itemType;
    public GameObject prefab;
    public int amount;
    
    public virtual void AddAmount(int value = 1)
    {
        amount += value;
    }
}