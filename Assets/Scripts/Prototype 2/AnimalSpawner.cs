using UnityEngine;

namespace Prototype2
{
    public class AnimalSpawner : MonoBehaviour
    {
        //[SerializeField]
        //private GameObject[] _animalPrefabs;

        [SerializeField]
        private PoolableObject[] _prefabs;

        [SerializeField]
        private float _startDelay = 2f;

        [SerializeField]
        private float _spawnInterval = 1.5f;

        [SerializeField]
        private float _xRange = 15f;
        [SerializeField]
        private float _zSpawnPos = 19f;

        private AnimalFactory _factory;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _factory = new AnimalFactory(_prefabs);
            InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
        }

        private void SpawnRandomAnimal()
        {
            // int index = Random.Range(0, _animalPrefabs.Length);

            float xSpawnCoord = Random.Range(-_xRange, _xRange);
            Vector3 spawnPos = new Vector3(xSpawnCoord, 0f, _zSpawnPos);

            var animal = _factory.GetRandomAnimal();
            animal.gameObject.transform.position = spawnPos;
            animal.gameObject.SetActive(true);

            // Instantiate(_animalPrefabs[index], spawnPos, _animalPrefabs[index].transform.rotation);
        }
    }
}