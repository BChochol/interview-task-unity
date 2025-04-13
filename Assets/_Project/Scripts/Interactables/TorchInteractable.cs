using UnityEngine;

namespace AE
{
    public class TorchInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            EventManager.Instance?.TorchInteracted();
        }
    }
}
