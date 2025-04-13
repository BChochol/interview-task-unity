using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")] 
        public float moveSpeed = 5f;
        public float jumpHeight = 2f;
        public float gravity = -9.81f;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private AudioClip walkingSound;

        [Header("Look Settings")] 
        [SerializeField] Transform _cameraToFollow;
        
        [Header("Ground Check Settings")]
        public Transform groundCheckOrigin;
        public float groundCheckDistance = 0.3f;
        public float groundCheckRadius = 0.4f;
        public LayerMask groundLayer;

        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _jumpAction;
        private InputAction _interactAction;

        private Vector2 _moveInput;
        private Vector2 _lookInput;
        private Vector3 _velocity;
        
        private bool _isGrounded;

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && _isGrounded)
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        
        private void LateUpdate()
        {
            HandleMovement();
            HandleLookAround();
        }
        
        private void HandleMovement()
        {
            Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            _controller.Move(move * moveSpeed * Time.deltaTime);

            _isGrounded = IsGrounded();
            if (_isGrounded && _velocity.y < 0)
                _velocity.y = -2f;

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
            
            if (_moveInput != Vector2.zero && _isGrounded)
            {
                AudioManager.Instance.PlayFootsteps(walkingSound);
            }
            else
            {
                AudioManager.Instance.StopFootsteps();
            }
        }

        private void HandleLookAround()
        {
            Vector3 lookDirection = _cameraToFollow.forward; 
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = targetRotation;
            }
        }
        
        private bool IsGrounded()
        {
            return Physics.SphereCast(
                groundCheckOrigin.position,
                groundCheckRadius,
                Vector3.down,
                out RaycastHit hit,
                groundCheckDistance,
                groundLayer,
                QueryTriggerInteraction.Ignore);
        }
        
        public bool CheckIfMoving()
        {
            return _moveInput != Vector2.zero;
        }
        
        public bool CheckIfGrounded()
        {
            return _isGrounded;
        }
    }
}