using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _range = 18f;
    [SerializeField] private Transform _shooterPoint;

    private Transform _playerTransform;

    private float _shootCooldown = 1f;
    private float _nextShootTime = 0f;

    private void Awake()
    {
        _playerTransform = transform;
    }

    public void TryShoot(out bool isCooldown)
    {
        if (Time.time >= _nextShootTime)
        {
            isCooldown = false;
            Shoot();
            _nextShootTime = Time.time + _shootCooldown;
        }
        else
        {
            isCooldown = true;
        }
    }

    private void Shoot()
    {
        Vector2 shootDirection = _playerTransform.right;

        RaycastHit2D hit = Physics2D.Raycast(_shooterPoint.position, shootDirection, _range);

        if (hit.collider != null)
        {
            CapsuleCollider2D capsuleCollider = hit.collider.GetComponent<CapsuleCollider2D>();

            if (capsuleCollider != null)
            {
                EnemyHealthContainer enemyHealth = hit.collider.GetComponentInParent<EnemyHealthContainer>();
                
                if (enemyHealth != null)
                {
                    enemyHealth.Reduce(_damage);
                }
            }   
        }
    }
}
