using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype5
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreTMP;
        private int _score = 0;

        [SerializeField]
        private GameObject _gameOverPnl;
        private bool _isGameActive = true;

        [SerializeField]
        private List<GameObject> _targetPrefabs;

        [SerializeField]
        private float _spawnRate = 1.0f;

        public void StartGame(int difficulty)
        {
            _spawnRate /= difficulty;
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
            while (_isGameActive)
            {
                yield return new WaitForSeconds(_spawnRate);
                var target = Instantiate(_targetPrefabs[Random.Range(0, _targetPrefabs.Count)]).GetComponent<Target>();
                // target.OnClicked -= UpdateScore;
                target.OnClicked += UpdateScore;
                target.GameOverEvent += () =>
                {
                    _gameOverPnl.SetActive(true);
                    _isGameActive = false;
                };
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}