using UnityEngine;

namespace Prototype3
{
    public class RepeatBackground : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 20f;

        private float _repeatWidth;
        private Vector3 _startPos;

        private BoxCollider _collider;

        void Start()
        {
            _startPos = transform.position;

            _collider = GetComponent<BoxCollider>();

            _repeatWidth = _collider.size.x / 2;
        }

        void Update()
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

            if (transform.position.x < _startPos.x - _repeatWidth)
            {
                transform.position = _startPos;
            }
        }
    }
}