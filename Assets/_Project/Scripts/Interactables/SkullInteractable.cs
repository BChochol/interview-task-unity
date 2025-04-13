using UnityEngine;

namespace AE
{
    public class SkullInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("interacted with skull");
        }
    }
}
