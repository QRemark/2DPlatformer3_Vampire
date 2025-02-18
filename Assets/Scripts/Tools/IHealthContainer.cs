using System;

public interface IHealthContainer
{
    public float MaxHealth { get; }
    public float CurrentHealth { get; }

    public event Action<float, float> HealthChanged;

    public void Increase(float volume);

    public void Reduce(float volume);
}
