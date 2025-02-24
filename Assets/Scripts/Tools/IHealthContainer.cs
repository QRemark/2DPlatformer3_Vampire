using System;

public interface IHealthContainer
{
    public float Max { get; }
    public float Current { get; }

    public event Action<float> Changed;

    public void Increase(float volume);

    public void Reduce(float volume);
}
