using Prototype2;
using UnityEngine;

namespace Prototype3
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private PoolableObject _prefab;

        [SerializeField]
        private Vector3 _spawnPos = new Vector3(23f, 0f, 0f);

        [SerializeField]
        private float _startDelay = 2f;
        [SerializeField]
        private float _spawnInterval = 1.5f;

        private ObjectPool<PoolableObject> _pool;

        void Start()
        {
            _pool = new ObjectPool<PoolableObject>(_prefab);
            InvokeRepeating(nameof(SpawnObstacle), _startDelay, _spawnInterval);
        }

        private void SpawnObstacle()
        {
            if (GameManager.IsGameOver) return;

            var obstacle = _pool.GetObject();
            obstacle.transform.position = _spawnPos;
            obstacle.gameObject.SetActive(true);
        }
    }
}