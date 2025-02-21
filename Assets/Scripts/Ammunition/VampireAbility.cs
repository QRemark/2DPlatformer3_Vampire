using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _radius;
    [SerializeField] private VampireAbilityBar _abilityBar;
    [SerializeField] private VampireAbilityAnimation _abilityAnimation;

    private Transform _playerTransform;
    private PlayerHealthContainer _playerHealth;

    private float _damagePerSecond = 3f;
    private float _workTime = 6f;
    private float _cooldown = 4f;

    private bool _isOnCooldown = false;

    public bool IsOnCooldown => _isOnCooldown;

    private void Awake()
    {
        _playerTransform = transform;
        _playerHealth = GetComponentInParent<PlayerHealthContainer>();
    }

    public void TryConsume()
    {
        if (_isOnCooldown) 
            return;

        StartCoroutine(ActiveVampirism());
    }

    private IEnumerator ActiveVampirism()
    {
        _isOnCooldown = true;
        _abilityBar.StartVampireBar(_workTime);
        _abilityAnimation.PlayVampireAbilityAnimation();

        float elapsedTime = 0f;

        while(elapsedTime < _workTime)
        {
            ConsumeHealth();
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _abilityAnimation.StopVampireAbilityAnimation();
        _abilityBar?.StartVampireBarCooldown(_cooldown);

        yield return new WaitForSeconds(_cooldown);
        _isOnCooldown = false;
    }

    private void ConsumeHealth()
    {
        EnemyHealthContainer nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null && nearestEnemy.CurrentHealth > 0)
        {
            TransferHealth(nearestEnemy);
        }
    }

    private EnemyHealthContainer FindNearestEnemy()
    {
        float range = _radius.bounds.extents.x;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerTransform.position, range);

        EnemyHealthContainer nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            EnemyHealthContainer enemy = collider.GetComponentInParent<EnemyHealthContainer>();

            if (enemy != null)
            {
                float distance = Vector2.Distance(_playerTransform.position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }

        return nearestEnemy;
    }

    private void TransferHealth(EnemyHealthContainer enemy)
    {
        float actualDamage = Mathf.Min(_damagePerSecond * Time.deltaTime, enemy.CurrentHealth);

        enemy.Reduce(actualDamage);
        _playerHealth?.Increase(actualDamage);
    }
}
