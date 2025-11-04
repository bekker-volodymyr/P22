using UnityEngine;

namespace Prototype1
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField]
        private Vector3 _offset = new Vector3(0f, 6f, -15f);

        void Start()
        {

        }

        void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}
