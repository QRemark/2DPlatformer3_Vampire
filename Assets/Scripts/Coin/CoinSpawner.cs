using UnityEngine;

public class CoinSpawner : Spawner<Coin>
{
    protected override Pool<Coin> CreatePool()
    {
        return GetComponent<Pool<Coin>>() ?? gameObject.AddComponent<Pool<Coin>>();
    }
}