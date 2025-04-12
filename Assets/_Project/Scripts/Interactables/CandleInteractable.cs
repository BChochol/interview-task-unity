using UnityEngine;

namespace AE
{
    public class CandleInteractable : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Destroy(gameObject);
        }
    }
}
