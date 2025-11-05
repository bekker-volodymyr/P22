using Prototype2;
using UnityEngine;

namespace Prototype3
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 20f;

        [SerializeField]
        private float _leftBound = -10f;

        private PoolableObject _poolable;

        void Start()
        {
            _poolable = GetComponent<PoolableObject>();
        }

        void Update()
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            if (transform.position.x < _leftBound)
            {
                _poolable.ReturnCallback();
            }
        }
    }
}