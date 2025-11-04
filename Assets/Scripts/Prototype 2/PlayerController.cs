using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _foodPrefab;

        [SerializeField]
        private float _speed = 25f;

        [SerializeField]
        private float _bound = 20f;

        private InputAction _moveAction;
        private InputAction _fireAction;

        private Vector2 _moveInput;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _fireAction = InputSystem.actions.FindAction("Fire");

            _moveAction.performed += OnMove;
            _moveAction.canceled += OnMove;
            _fireAction.performed += OnFire;
        }

        private void OnFire(InputAction.CallbackContext context)
        {
            // Spawn food
            Instantiate(_foodPrefab, transform.position, Quaternion.identity);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Mathf.Abs(transform.position.x) > _bound)
            {
                transform.position = new Vector3
                    (
                    (transform.position.x < 0 ? -_bound : _bound),
                        0f, 0f
                    );
            }

            transform.Translate(Vector3.right * _speed * Time.deltaTime * _moveInput.x);
        }
    }
}
