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

        private void Update()
        {
            CheckRaycast();
        }

        private void CheckRaycast()
        {
            RaycastHit hit;
            Debug.DrawRay(interactionOrigin.position, interactionOrigin.forward * interactionDistance, Color.red);
            if (Physics.Raycast(interactionOrigin.position, interactionOrigin.forward, out hit, interactionDistance, interactionLayer))
            {
                if (!_isRaycasting)
                {
                    _isRaycasting = true;
                    Debug.Log(hit.collider.tag);
                }
                Debug.DrawRay(interactionOrigin.position, interactionOrigin.forward * interactionDistance, Color.green);
            }
            else
            {
                if (_isRaycasting)
                {
                    _isRaycasting = false;
                    Debug.Log("Not interacting anymore.");
                }
            }
        }
    }
}