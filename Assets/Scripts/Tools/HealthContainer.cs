using System;
using UnityEngine;

public abstract class HealthContainer : MonoBehaviour, IHealthContainer
{
    protected float _max;
    private float _current;

    public event Action<float> Changed;

    public float Max => _max;
    public float Current => _current;

    protected virtual void Start()
    {
        _current = _max;
        Changed?.Invoke(_current);
    }

    public void Increase(float volume)
    {
        _current = Mathf.Clamp(_current + volume, 0, _max);
        Changed?.Invoke(_current);
    }

    public void Reduce(float volume)
    {
        _current = Mathf.Clamp(_current - volume, 0, _max);
        Changed?.Invoke(_current);
    }
}
