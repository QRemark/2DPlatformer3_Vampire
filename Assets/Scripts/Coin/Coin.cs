using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour, ICollectible
{
    public event Action<ICollectible> OnCollected;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }
}
