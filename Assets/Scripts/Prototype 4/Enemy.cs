using System;
using UnityEngine;

namespace Prototype4
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 8.5f;

        public event Action DeathEvent;

        private Rigidbody _rb;

        private GameObject _player;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();

            _player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 lookDir = (_player.transform.position - transform.position).normalized;
            _rb.AddForce(lookDir * _speed);

            if (transform.position.y < -15f)
            {
                DeathEvent?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}