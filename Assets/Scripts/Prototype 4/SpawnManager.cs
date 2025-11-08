using UnityEngine;

namespace Prototype4
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;

        [SerializeField]
        private float _spawnRadius = 10f;

        void Start()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPos = GenerateRandomPoint();

            Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        }

        private Vector3 GenerateRandomPoint()
        {
            float spawnX = Random.Range(-_spawnRadius, _spawnRadius);
            float spawnZ = Random.Range(-_spawnRadius, _spawnRadius);
            Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
            return spawnPos;
        }

        void Update()
        {

        }
    }
}