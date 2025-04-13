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
                    EventManager.Instance.UITargetSwitched(false);
                    EventManager.Instance.UITutorialUpdate("Press [E] to interact");
                }
            }
            else
            {
                if (_isRaycasting)
                {
                    _isRaycasting = false;
                    _interactableContainer = null;
                    EventManager.Instance.UITargetSwitched(true);
                    EventManager.Instance.UITutorialUpdate("");
                }
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Interact");
                _interactableContainer?.Interact();
            }
        }

    }
}