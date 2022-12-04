using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    public float timeToDestroy;
    public Vector3 direction;
    public int damageAmount = 1;

    public float side = 1;
    public bool isEnemy = false;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();
        var player = collision.transform.GetComponent<Player>();

        if (enemy != null)
        {
                enemy.Damage(damageAmount);
                Destroy(gameObject);
            
        }
        else if (player != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.healthBase.Damage(damageAmount);
                Destroy(gameObject);
            }
            
        }
    }
}
