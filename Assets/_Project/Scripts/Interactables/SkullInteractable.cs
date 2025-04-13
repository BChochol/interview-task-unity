using UnityEngine;

namespace AE
{
    public class SkullInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private int skullNumber;
        public void Interact()
        {
            EventManager.Instance?.SkullInteracted(skullNumber);
        }
    }
}
