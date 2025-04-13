using UnityEngine;

namespace AE
{
    public class SkullInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private int skullNumber;
        public void Interact()
        {
            EventManager.Instance?.SkullInteracted(skullNumber);
            EventManager.Instance.UIMonologueUpdate("The skull moved a little and something clicked inside.", 3.5f);
        }
    }
}
