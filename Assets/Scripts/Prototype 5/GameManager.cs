using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Prototype5
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreTMP;
        private int _score = 0;

        [SerializeField]
        private List<GameObject> _targetPrefabs;

        [SerializeField]
        private float _spawnRate = 1.0f;

        void Start()
        {
            _scoreTMP.text = $"Score: {_score}";
            StartCoroutine(SpawnTargetCoroutine());
        }

        private void UpdateScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            _scoreTMP.text = $"Score: {_score}";
        }

        private IEnumerator SpawnTargetCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                var target = Instantiate(_targetPrefabs[Random.Range(0, _targetPrefabs.Count)]).GetComponent<Target>();
                // target.OnClicked -= UpdateScore;
                target.OnClicked += UpdateScore;
            }
        }
    }
}