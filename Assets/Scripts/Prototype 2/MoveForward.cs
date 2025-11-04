using UnityEngine;

namespace Prototype2
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 30f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}