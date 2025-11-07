using UnityEngine;
using UnityEngine.InputSystem;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        private Animator _animator;
        private AudioSource _audioSource;

        [SerializeField]
        private AudioSource _musicSource;

        [SerializeField]
        private AudioClip _crashSound;
        [SerializeField]
        private AudioClip _jumpSound;

        [SerializeField]
        private ParticleSystem _explosionEffect;
        [SerializeField]
        private ParticleSystem _dirtEffect;

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

            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();

            _jumpAction = InputSystem.actions.FindAction("Jump");
            _jumpAction.performed += Jump;
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_isGrounded && !GameManager.IsGameOver)
            {
                _audioSource.PlayOneShot(_jumpSound, 1.0f);
                _dirtEffect.Stop();
                _animator.SetTrigger("Jump_trig");
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                if (!GameManager.IsGameOver)
                {
                    _dirtEffect.Play();
                }
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(_musicSource);
                //_musicSource.volume = 0.1f;
                _audioSource.PlayOneShot(_crashSound, 1.0f);
                _dirtEffect.Stop();
                _explosionEffect.Play();
                _animator.SetBool("Death_b", true);
                _animator.SetInteger("DeathType_int", 1);
                GameManager.IsGameOver = true;
            }
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