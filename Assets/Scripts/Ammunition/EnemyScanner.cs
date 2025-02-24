using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    private List<EnemyHealthContainer> _enemiesInRadius = new List<EnemyHealthContainer>();

    public EnemyHealthContainer GetNearestEnemy(Vector2 position)
    {
        EnemyHealthContainer nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (EnemyHealthContainer enemy in _enemiesInRadius)
        {
            if (enemy != null && enemy.CurrentHealth > 0)
            {
                if (position.IsCloserThan(enemy.transform.position, minDistance))
                {
                    minDistance = position.SqrDistance(enemy.transform.position);
                    nearestEnemy = enemy;
                }
            }
        }

        return nearestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (((1 << collider.gameObject.layer) & _enemyLayer) == 0)
            return;

        EnemyHealthContainer enemy = collider.GetComponentInParent<EnemyHealthContainer>();

        if (enemy != null && !_enemiesInRadius.Contains(enemy))
        {
            _enemiesInRadius.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (((1 << collider.gameObject.layer) & _enemyLayer) == 0)
            return;

        EnemyHealthContainer enemy = collider.GetComponentInParent<EnemyHealthContainer>();

        if (enemy != null)
        {
            _enemiesInRadius.Remove(enemy);
        }
    }
}

