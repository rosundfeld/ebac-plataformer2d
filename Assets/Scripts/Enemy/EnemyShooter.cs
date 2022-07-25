using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    [Header("Enemy Shooter")]
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = 3f;
    public Transform enemySide;

    private Coroutine _currentCoroutine;
    private bool _shooting = false;

    void Update()
    {
        if (!_shooting)
        {
            if (checkIfPlayerIsNear())
            {
                _currentCoroutine = StartCoroutine(StartShoot());
            }
            else
                if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        _shooting = true;
        Shoot();
        yield return new WaitForSeconds(timeBetweenShoot);
        _shooting = false;
        _currentCoroutine = null;

    }

    private void Shoot()
    {
        PlayAttackAnimation();
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = enemySide.transform.localScale.x;
    }

}
