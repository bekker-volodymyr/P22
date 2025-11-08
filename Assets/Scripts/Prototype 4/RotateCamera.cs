using UnityEngine;

namespace Prototype4
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 150f;

        void Update()
        {
            float horInput = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime * horInput);
        }
    }
}