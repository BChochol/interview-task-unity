using UnityEngine;

namespace AE
{
    public class ItemInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemData itemData;
        public void Interact()
        {
            if (SceneManager.Instance.Inventory != null && itemData != null)
            {
                SceneManager.Instance.Inventory.AddItem(itemData);
            }
            Destroy(gameObject);
        }
        
        
    }
}
