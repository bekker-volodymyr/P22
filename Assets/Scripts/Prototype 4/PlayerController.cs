using System.Collections;
using UnityEngine;

namespace Prototype4
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;

        private GameObject _focalPoint;

        private Rigidbody _rb;

        private bool _hasPowerUp = false;
        [SerializeField]
        private float _powerUpStrength = 30f;
        [SerializeField]
        private float _powerUpCoundown = 5f;

        [SerializeField]
        private GameObject _powerUpIndicator;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();

            _focalPoint = GameObject.Find("Focal Point");
        }

        void Update()
        {
            _powerUpIndicator.transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 0.25f,
                transform.position.z);

            float _fwdInput = Input.GetAxis("Vertical");
            _rb.AddForce(_focalPoint.transform.forward * _speed * _fwdInput);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PowerUp"))
            {
                _hasPowerUp = true;
                _powerUpIndicator.SetActive(true);
                StartCoroutine(PowerUpCountdownRoutine());
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
            {
                Debug.Log($"Collision with {collision.gameObject.name}. Has power up: {_hasPowerUp}");
                Vector3 pushDir = (collision.gameObject.transform.position - transform.position).normalized;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDir * _powerUpStrength, ForceMode.Impulse);
            }
        }

        private IEnumerator PowerUpCountdownRoutine()
        {
            // logic
            yield return new WaitForSeconds(_powerUpCoundown);
            // logic
            // yield return 
            _hasPowerUp = false;
            _powerUpIndicator.SetActive(false);
        }
    }
}