using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;

        [SerializeField]
        private float _jumpForce = 250f;
        [SerializeField]
        private float _gravityModifier = 1.5f;

        private InputAction _jumpAction;

        private bool _isGrounded = true;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            Physics.gravity *= _gravityModifier;

            _jumpAction = InputSystem.actions.FindAction("Jump");
            _jumpAction.performed += Jump;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            _isGrounded = true;
        }

        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            //}
        }
    }
}