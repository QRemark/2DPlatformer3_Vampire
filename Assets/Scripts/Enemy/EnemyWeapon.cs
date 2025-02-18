using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private PlayerHealthContainer _playerHealth;
    private ITargetable _target;
    
    private float _attackRadius = 2f;
    private float _attackColldown = 2f;

    private bool _isAttack = false;
    private float _nextAttackTime = 0f;
    private float _attckRange = 25f;

    private void Start()
    {
        _target = GetComponentInParent<EnemyMover>().GetPlayer();

        if (_target is MonoBehaviour monoBehaviour)
            _playerHealth = monoBehaviour.GetComponent<PlayerHealthContainer>();
    }

    private void Update()
    {
        if (_isAttack == false || Time.time < _nextAttackTime)
            return;

        AttackPlayer();
    }

    public void StartAttack() => _isAttack = true;

    public void StopAttack() => _isAttack = false;

    private void AttackPlayer()
    {
        float distance = Vector2.Distance(transform.position, _playerHealth.transform.position);

        if (distance <= _attackRadius)
        {
            _playerHealth.Reduce(_attckRange);
            _nextAttackTime = Time.time + _attackColldown;
        }
    }
}
