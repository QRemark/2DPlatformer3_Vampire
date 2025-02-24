using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private EnemyWeapon _enemyWeapon;

    private ITargetable _target;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyWeapon = GetComponent<EnemyWeapon>();
        EnemyEye eye = GetComponentInChildren<EnemyEye>();
        eye.OnEnterSight += HandleEnterSight;
        eye.OnExitSight += HandleExitSight;
    }

    public void SetPlayerTarget(ITargetable target)
    {
        _target = target;
        _enemyMover.SetTarget(target);
    }

    public void SetPath(EnemyPath path)
    {
        _enemyMover.SetPath(path);
    }

    private void HandleEnterSight(Collider2D collider)
    {
        if (collider.transform == _target.Transform)
        {
            _enemyMover.WalkPlayerEnterSight();
            _enemyWeapon.StartAttack();
        }
    }

    private void HandleExitSight(Collider2D collider)
    {
        if (collider.transform == _target.Transform)
        {
            _enemyMover.WalkPlayerExitSight();
            _enemyWeapon.StopAttack();
        }
    }
}

