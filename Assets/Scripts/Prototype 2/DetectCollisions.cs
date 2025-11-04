using UnityEngine;

namespace Prototype2
{
    public class DetectCollisions : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}