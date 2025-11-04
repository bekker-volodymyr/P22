using UnityEngine;

namespace Prototype2
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        [SerializeField]
        private float _upperBound = 20f;

        [SerializeField]
        private float _lowerBound = -5f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.z > _upperBound)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z < _lowerBound)
            {
                Destroy(gameObject);
                Debug.Log("GAME OVER");
                Time.timeScale = 0f;
            }
        }
    }
}