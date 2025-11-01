using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float _turnSpeed = 25f;

    private float _horInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Debug.Log("Method Start");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Method Update");
        // transform.Translate(0f, 0f, 1f);

        _horInput = Input.GetAxis("Horizontal");

        // transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horInput);
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // 1м на сек
    }
}
