using UnityEngine;
using UnityEngine.UI;

namespace Prototype5
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button _button;

        private GameManager _gameManager;

        [SerializeField]
        private int _difficulty;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SetDifficulty);

            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        private void SetDifficulty()
        {
            _gameManager.StartGame(_difficulty);
            transform.parent.gameObject.SetActive(false);
            Debug.Log($"{gameObject.name} was clicked");
        }
    }
}