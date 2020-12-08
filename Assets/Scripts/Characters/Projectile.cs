using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectiles simply move until they hit something or self destruct
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField] float selfDestructTime = 5f;
    [SerializeField] float projectileImpulse = 20f;
    [SerializeField] int projectileDamage = 10;

    // The person who shot this projectile.
    public ACharacter Owner { get; set; }

    float timer = 0f;
    Rigidbody2D rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = selfDestructTime;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * projectileImpulse, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Character", System.StringComparison.Ordinal))
        {
            // Don't damage your owner!
            if (collision.gameObject == Owner.gameObject)
                return;
            // Damage the character hit
            collision.gameObject.GetComponent<ACharacter>().TakeDamage(projectileDamage);
            Destroy(this.gameObject);
        }
    }
}
