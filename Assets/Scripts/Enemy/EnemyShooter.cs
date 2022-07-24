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

    void Update()
    {
        if (checkIfPlayerIsNear())
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else
            if (_currentCoroutine != null)
                    StopCoroutine(_currentCoroutine);
        }

    IEnumerator StartShoot()
    {
        Shoot();
        Debug.Log("Famoso segundo");
        yield return new WaitForSeconds(timeBetweenShoot);
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = enemySide.transform.localScale.x;
    }

}
