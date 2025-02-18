using System.Collections;
using UnityEngine;

public class VampireAbility : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _radius;

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

    //public void TryConsume()
    //{
    //    if (_isOnCooldown)
    //    {
    //        _isOnCooldown = true;
    //        Debug.Log("cooldown on");
    //        return;
    //    }

    //    _isOnCooldown = false;
    //    Debug.Log("cooldown offfffffffffff");
    //    StartCoroutine(ActiveVampirism());
    //}

    public void TryConsume()
    {
        if (_isOnCooldown) return;
        StartCoroutine(ActiveVampirism());
    }

    private IEnumerator ActiveVampirism()
    {
        _isOnCooldown = true;

        float elapsedTime = 0f;

        while(elapsedTime < _workTime)
        {
            ConsumeHealth();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //_isOnCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _isOnCooldown = false;
    }

    private void ConsumeHealth()
    {
        float range = _radius.bounds.extents.x;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerTransform.position, range);

        EnemyHealthContainer nearestEnemy = null;

        float minDistance = Mathf.Infinity;

        foreach(Collider2D collider in colliders)
        {
            EnemyHealthContainer enemy = collider.GetComponentInParent<EnemyHealthContainer>();

            if(enemy != null)
            {
                float distance = Vector2.Distance(_playerTransform.position, collider.transform.position);
                
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }

        if(nearestEnemy != null)
        {
            nearestEnemy.Reduce(_damagePerSecond * Time.deltaTime);

            _playerHealth?.Increase(_damagePerSecond * Time.deltaTime);
        }
    }
}
