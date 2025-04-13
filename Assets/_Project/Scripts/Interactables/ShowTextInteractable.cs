using UnityEngine;

namespace AE
{
    public class ShowTextInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string textToShow;
        [SerializeField] private float duration = 3.0f;
        public void Interact()
        {
            EventManager.Instance.UIMonologueUpdate(textToShow, duration);
        }
    }
}
