using UnityEngine;

namespace AE
{
    public class TorchInteractable : MonoBehaviour, IInteractable
    {
        [Header("Interactable Settings")]
        [SerializeField] private ItemData interactingItem;
        [SerializeField] private AudioClip torchSound;
        public void Interact()
        {
            ItemData heldItem = EventManager.Instance.HeldItemCheck();
            if (heldItem != interactingItem)
            {
                AudioManager.Instance.PlaySFX(torchSound);
                EventManager.Instance.UIMonologueUpdate("It won't budge.", 1.5f);
            }else EventManager.Instance?.TorchInteracted();
        }
    }
}
