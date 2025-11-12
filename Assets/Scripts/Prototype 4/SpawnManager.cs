using UnityEngine;

namespace Prototype4
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;
        [SerializeField]
        private GameObject _powerUpPrefab;

        [SerializeField]
        private float _spawnRadius = 10f;

        private int _enemyCount;
        private int _waveNumber = 1;

        void Start()
        {
            // SpawnEnemy();
            SpawnEnemyWave(_waveNumber);
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPos = GenerateRandomPoint();

            var enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity).GetComponent<Enemy>();
            _enemyCount++;
            enemy.DeathEvent += () => _enemyCount--;
        }

        private Vector3 GenerateRandomPoint()
        {
            float spawnX = Random.Range(-_spawnRadius, _spawnRadius);
            float spawnZ = Random.Range(-_spawnRadius, _spawnRadius);
            Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
            return spawnPos;
        }

        private void SpawnEnemyWave(int spawnCount)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }
            Instantiate(_powerUpPrefab, GenerateRandomPoint(), Quaternion.identity);
        }

        void Update()
        {
            // _enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

            if (_enemyCount == 0)
            {
                SpawnEnemyWave(++_waveNumber);
            }
        }
    }
}