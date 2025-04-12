using System.Collections.Generic;
using UnityEngine;

namespace AE
{
    public class ItemPool : MonoBehaviour
    {
        public static ItemPool Instance;
        private Dictionary<ItemData, Queue<GameObject>> pool = new();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public GameObject GetItem(ItemData itemData)
        {
            if (!pool.ContainsKey(itemData))
                pool[itemData] = new Queue<GameObject>();

            if (pool[itemData].Count == 0)
            {
                var obj = Instantiate(itemData.prefab);
                obj.SetActive(false);
                pool[itemData].Enqueue(obj);
            }

            GameObject item = pool[itemData].Dequeue();
            item.SetActive(true);
            return item;
        }

        public void ReturnItem(ItemData type, GameObject item)
        {
            item.SetActive(false);
            pool[type].Enqueue(item);
        }
    }
}
