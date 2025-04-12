using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class Interactor : MonoBehaviour
    {
        [Header("Interaction Settings")]
        public float interactionDistance = 3f;  
        public LayerMask interactionLayer;     
        public Transform interactionOrigin;     
        
        [Header("Visual Settings")]
        public GameObject baseTargetIcon;
        public GameObject interactableTargetIcon;

        private bool _isRaycasting;  
        private IInteractable _interactableContainer;

        private void Update()
        {
            CheckRaycast();
        }

        private void CheckRaycast()
        {
            RaycastHit hit;
            if (Physics.Raycast(interactionOrigin.position, interactionOrigin.forward, out hit, interactionDistance, interactionLayer))
            {
                if (!_isRaycasting)
                {
                    _isRaycasting = true;
                    _interactableContainer = hit.collider.GetComponent<IInteractable>();
                    SetInteractionIcon(true);
                }
            }
            else
            {
                if (_isRaycasting)
                {
                    _isRaycasting = false;
                    _interactableContainer = null;
                    SetInteractionIcon(false);
                }
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _interactableContainer?.Interact();
            }
        }

        private void SetInteractionIcon(bool isInteractionIcon)
        {
            baseTargetIcon.SetActive(!isInteractionIcon);
            interactableTargetIcon.SetActive(isInteractionIcon);
        }
    }
}