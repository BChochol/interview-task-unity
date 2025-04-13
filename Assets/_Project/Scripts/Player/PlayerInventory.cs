using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace AE
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<ItemData> items; 
        public Transform handSlot;

        private ItemData equippedItem;
        private GameObject currentVisual;

        private void Start()
        {
            EventManager.Instance.OnItemCollected += AddItem;
            AutoEquip();
        }
        
        public void OnItemSwitchNext(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ChangeEquippedItem(1);
            }
        }
        
        public void OnItemSwitchPrev(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ChangeEquippedItem(-1);
            }
        }

        public void Equip(ItemData item)
        {
            if (currentVisual != null)
            {
                ItemPool.Instance.ReturnItem(equippedItem, currentVisual);
                currentVisual = null;
            }

            equippedItem = item;
            
            if (equippedItem.amount > 0)
            {
                currentVisual = ItemPool.Instance.GetItem(equippedItem);
                currentVisual.transform.SetParent(handSlot);
                currentVisual.transform.localPosition = Vector3.zero;
            }
            
        }

        public void ChangeEquippedItem(int direction)
        {

            int index = items.IndexOf(equippedItem);
            int nextIndex = index;

            do
            {
                nextIndex = (nextIndex + direction + items.Count) % items.Count;
            } while (items[nextIndex].amount == 0 && nextIndex != index);

            Debug.Log("Equipping " + items[nextIndex].name);
            Equip(items[nextIndex]);
        }

        private void AutoEquip()
        {
            foreach (var item in items)
            {
                if (item.amount > 0)
                {
                    Equip(item);
                    return;
                }
            }

            ItemData empty = items.Find(i => i.itemType == ItemType.Empty);
            Equip(empty);
        }
        
        public void AddItem(ItemData item)
        {
            ItemData existing = items.Find(i => i == item);
            if (existing != null)
            {
                existing.AddAmount(1);
            }
            else
            {
                items.Add(Instantiate(item));
                item.AddAmount();
            }
            Equip(item);
        }
    }
}
