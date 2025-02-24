using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private EnemyScanner _enemyScanner;
    [SerializeField] private VampireAbilityBar _abilityBar;
    [SerializeField] private VampireAbilityAnimation _abilityAnimation;

    private PlayerHealthContainer _playerHealth;

    private float _damagePerSecond = 3f;
    private float _workTime = 6f;
    private float _cooldown = 4f;

    private bool _isOnCooldown = false;

    private WaitForSeconds _waitCooldown;

    public bool IsOnCooldown => _isOnCooldown;

    private void Awake()
    {
        _playerHealth = GetComponentInParent<PlayerHealthContainer>();
        _waitCooldown = new WaitForSeconds(_cooldown);
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

        yield return _waitCooldown;
        _isOnCooldown = false;
    }

    private void ConsumeHealth()
    {
        EnemyHealthContainer nearestEnemy = _enemyScanner.GetNearestEnemy(transform.position);

        if (nearestEnemy != null)
        {
            TransferHealth(nearestEnemy);
        }
    }

    private void TransferHealth(EnemyHealthContainer enemy)
    {
        float actualDamage = Mathf.Min(_damagePerSecond * Time.deltaTime, enemy.Current);

        enemy.Reduce(actualDamage);
        _playerHealth?.Increase(actualDamage);
    }
}
