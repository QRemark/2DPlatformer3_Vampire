using UnityEngine;

public class CoinSpawner : Spawner<Coin>
{
    protected override Pool<Coin> CreatePool()
    {
        return GetComponent<Pool<Coin>>() ?? gameObject.AddComponent<Pool<Coin>>();
    }
}

//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(CoinPool))]
//public class CoinSpawner : MonoBehaviour
//{
//    [SerializeField] private Coin  _prefab;
//    [SerializeField] private List<Transform> _spawnPoints;

//    private int _poolCapacity = 5;

//    private CoinPool _coinPool;

//    private void Awake()
//    {
//        _coinPool = gameObject.GetComponent<CoinPool>();
//        _coinPool.Initialize(_prefab, _poolCapacity);
//    }

//    private void Start()
//    {
//        SpawnCoins();
//    }

//    public void SpawnCoins()
//    {
//        for (int i = 0; i < _spawnPoints.Count; i++)
//        {
//            Coin coin = _coinPool.GetObject();

//            if (coin != null)
//            {
//                coin.transform.position = _spawnPoints[i].position;
//                coin.OnCollected += ReturnCoinInPool;
//            }
//        }
//    }

//    public void ReturnCoinInPool(Coin coin)
//    {
//        coin.OnCollected -= ReturnCoinInPool;
//        _coinPool.ReleaseObject(coin);
//    }

//#if UNITY_EDITOR
//    [ContextMenu("Refresh Child Array")]
//    private void RefreshChildArray()
//    {
//        int pointCount = transform.childCount;
//        _spawnPoints = new List<Transform>();

//        for (int i = 0; i < pointCount; i++)
//            _spawnPoints.Add(transform.GetChild(i));
//    }
//#endif
//}
