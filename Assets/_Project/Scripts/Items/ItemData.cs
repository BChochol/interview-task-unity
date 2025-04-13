using UnityEngine;

public enum ItemType { Empty, Collectable, Candle }

public abstract class ItemData : ScriptableObject
{
    [SerializeField]  public ItemType itemType;
    [SerializeField]  public GameObject prefab;
    [SerializeField]  public int amount;
    [SerializeField] private int startingAmount = 0;
    
    public void AddAmount(int value = 1)
    {
        amount += value;
    }
    
    private void OnEnable()
    {
        Debug.Log("Was " + amount + " ,set " + startingAmount + " for " + name);
        amount = startingAmount;
    }
}