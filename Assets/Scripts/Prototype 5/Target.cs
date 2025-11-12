using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rb;
    private float _xRange = 4.3f;

    [SerializeField]
    private float _minForce = 10f;
    private float _maxForce = 15f;

    [SerializeField]
    private float _rangeTorque = 10f;

    [SerializeField]
    private int _score;

    [SerializeField]
    private ParticleSystem _particleSystem;

    public event Action<int> OnClicked;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        transform.position = GetRandomPos();

        _rb.AddForce(Vector3.up * GetRandomForce(), ForceMode.Impulse);
        _rb.AddTorque(
            GetRandomTorque(),
            GetRandomTorque(),
            GetRandomTorque(),
            ForceMode.Impulse
            );
    }

    private Vector3 GetRandomPos()
    {
        return new Vector3(UnityEngine.Random.Range(-_xRange, _xRange), -1f);
    }

    private float GetRandomForce()
    {
        return UnityEngine.Random.Range(_minForce, _maxForce);
    }

    private float GetRandomTorque()
    {
        return UnityEngine.Random.Range(-_rangeTorque, _rangeTorque);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        OnClicked?.Invoke(_score);
        // _particleSystem.Play();
        Instantiate(_particleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
