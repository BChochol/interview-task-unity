using UnityEngine;
using UnityEngine.InputSystem;

namespace AE
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")] public float moveSpeed = 5f;
        public float jumpHeight = 2f;
        public float gravity = -9.81f;

        [Header("Look Settings")] public Transform cameraTransform;
        public float lookSensitivity = 1f;
        public float verticalLookLimit = 80f;

        [Header("Interaction Settings")] public float interactionDistance = 3f;
        public LayerMask interactionLayer;

        private CharacterController _controller;
        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _jumpAction;
        private InputAction _interactAction;

        private Vector2 _moveInput;
        private Vector2 _lookInput;
        private Vector3 _velocity;
        
        private float _xRotation = 0f;
        private bool _isGrounded;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();

            if (cameraTransform == null)
            {
                Debug.LogWarning("Camera Transform not assigned.");
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnLookAround(InputAction.CallbackContext context)
        {
            _lookInput = context.ReadValue<Vector2>() * lookSensitivity;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed && _isGrounded)
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                //TO DO
            }
        }
        
        private void Update()
        {
            HandleMovement();
            HandleLookAround();
        }
        
        private void HandleMovement()
        {
            Vector3 move = transform.right * _moveInput.x + transform.forward * _moveInput.y;
            _controller.Move(move * moveSpeed * Time.deltaTime);

            _isGrounded = _controller.isGrounded;
            if (_isGrounded && _velocity.y < 0)
                _velocity.y = -2f;

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        private void HandleLookAround()
        {
            _xRotation -= _lookInput.y;
            _xRotation = Mathf.Clamp(_xRotation, -verticalLookLimit, verticalLookLimit);
            cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * _lookInput.x);
        }
    }
}