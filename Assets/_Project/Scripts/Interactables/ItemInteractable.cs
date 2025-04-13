using UnityEngine;

namespace AE
{
    public class ItemInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemData itemData;
        
        public void Interact()
        {
            if (EventManager.Instance != null && itemData != null)
            {
                EventManager.Instance?.ItemCollected(itemData);
            }
            Destroy(gameObject);
        }
        
        
    }
}
