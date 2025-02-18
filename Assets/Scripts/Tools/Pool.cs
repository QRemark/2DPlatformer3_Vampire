using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    private Queue<T> _deactiveObjects;

    private T _prefab;

    public void Initialize(T prefab, int initialSize)
    {
        _prefab = prefab;
        _deactiveObjects = new Queue<T>();

        for (int i = 0; i < initialSize; i++)
        {
            T obj = Create();
            obj.gameObject.SetActive(false);
            _deactiveObjects.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        T @object;

        if (_deactiveObjects.Count > 0)
            @object = _deactiveObjects.Dequeue();
        else
            @object = Create();

        @object.gameObject.SetActive(true);
        return @object;
    }

    public void ReleaseObject(T @object)
    {
        @object.gameObject.SetActive(false);
        _deactiveObjects.Enqueue(@object);
    }

    private T Create()
    {
        T @object = Instantiate(_prefab);
        return @object;
    }
}
