using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    public float timeToDestroy = 1f;

    public bool playerIsNear = false;
    public float timeToScanPlayer = 1f;
    
    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill; // adicionando OnEnemyKill no callback
        }
    }

    private void Update()
    {
        checkIfPlayerIsNear();
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill; // callbacks funcionam como um Watcher?
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    public bool checkIfPlayerIsNear()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 31f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 31f);

        if (hit != false && hit.transform.tag == "Player")
            return true;
        else
            return false;

    }

    IEnumerator ScanPLayer()
    {
        checkIfPlayerIsNear();
        Debug.Log("Famoso segundo");
        yield return new WaitForSeconds(timeToScanPlayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        var player = collision.gameObject.GetComponent<Player>();

        if (health != null && player != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
