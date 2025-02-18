using System;
using UnityEngine;

public abstract class HealthContainer : MonoBehaviour, IHealthContainer
{
    protected float _maxHealth;
    private float _currentHealth;

    public event Action<float,float> HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Increase(float volume)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + volume, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Reduce(float volume)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - volume, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
