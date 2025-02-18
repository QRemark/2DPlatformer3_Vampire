using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ICollectible
{
    [SerializeField] private T _prefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private int _poolCapacity = 5;
    private Pool<T> _pool;

    protected abstract Pool<T> CreatePool();

    private void Awake()
    {
        _pool = GetComponent<Pool<T>>();

        if (_pool == null)
        {
            _pool = gameObject.AddComponent<Pool<T>>(); 
        }

        _pool.Initialize(_prefab, _poolCapacity);
    }

    private void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            T obj = _pool.GetObject();

            if (obj != null)
            {
                obj.transform.position = _spawnPoints[i].position;
                obj.OnCollected += ReturnObjectInPool;
            }
        }
    }

    private void ReturnObjectInPool(ICollectible collectible)
    {
        collectible.OnCollected -= ReturnObjectInPool;
        _pool.ReleaseObject((T)collectible);
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _spawnPoints = new List<Transform>();

        for (int i = 0; i < pointCount; i++)
            _spawnPoints.Add(transform.GetChild(i));
    }
#endif
}
