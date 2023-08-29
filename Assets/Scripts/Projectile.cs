using HealthSystem;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb2d;
    public float deathDelay = 5;

    public bool disabled = false;

    private int initialHealthValue = 1;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    void Start()
    {
        health.InitializeHealth(initialHealthValue);
        rb2d.velocity = transform.up * speed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();

        if(hittable != null)
        {
            hittable.GetHit(1, gameObject);
            Death();
        }
    }

    private void Death()
    {
        health.GetHit(1, gameObject);
        Destroy(gameObject);
    }
}
