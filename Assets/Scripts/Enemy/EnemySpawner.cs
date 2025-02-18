using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(EnemyPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<EnemyPath> _enemyPaths;
    //[SerializeField] private Player _palyerTarget;

    [SerializeField] private MonoBehaviour _playerTarget;

    private ITargetable _target;

    private int _poolCapacity = 3;
    private int _startPoint  = 0;

    private EnemyPool _enemyPool;

    private void Awake()
    {
        _enemyPool = gameObject.GetComponent<EnemyPool>();
        _enemyPool.Initialize(_prefab, _poolCapacity);
        //_target = _playerTarget as ITargetable;
        _target = _playerTarget.GetComponent<ITargetable>();
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemyPaths.Count; i++)
        {
            Enemy enemy = _enemyPool.GetObject();

            if (enemy != null)
            {
                enemy.SetPath(_enemyPaths[i]);
                enemy.transform.position = _enemyPaths[i].Points[_startPoint].position;
                //enemy.SetPlayerTarget(_palyerTarget);
                enemy.SetPlayerTarget(_target);
            }
        }
    }
}