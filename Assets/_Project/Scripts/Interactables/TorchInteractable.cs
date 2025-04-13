using UnityEngine;

namespace AE
{
    public class TorchInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            ItemType heldItem = EventManager.Instance.HeldItemCheck();
            if (heldItem != ItemType.Candle)
            {
                EventManager.Instance.UIMonologueUpdate("It won't budge.", 2f);
            }
            
            EventManager.Instance?.TorchInteracted();
        }
    }
}
