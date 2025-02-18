using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MedicineChest : MonoBehaviour, ICollectible
{
    public event Action<ICollectible> OnCollected;

    private float _healthRange = 21f;

    public void Collect()
    {
        OnCollected?.Invoke(this);
    }

    public float GetHealthRange() => _healthRange;
}
