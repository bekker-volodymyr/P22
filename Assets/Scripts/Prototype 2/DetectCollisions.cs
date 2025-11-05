using UnityEngine;

namespace Prototype2
{
    [RequireComponent(typeof(PoolableObject))]
    public class DetectCollisions : MonoBehaviour
    {
        private PoolableObject _poolable;

        private void Start()
        {
            _poolable = GetComponent<PoolableObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<PoolableObject>().ReturnCallback();
            _poolable.ReturnCallback();
            // Destroy(gameObject);
            // Destroy(other.gameObject);
        }
    }
}