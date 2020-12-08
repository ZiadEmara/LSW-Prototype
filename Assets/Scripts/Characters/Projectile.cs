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
        // Apply an impulse force as soon as the projectile spawns
        rb.AddForce(transform.right * projectileImpulse, ForceMode2D.Impulse);
        timer = selfDestructTime;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make sure that enemies don't hit each other
        if ((collision.tag.Equals("Character", System.StringComparison.Ordinal)
            || collision.tag.Equals("Player", System.StringComparison.Ordinal))
            && (!collision.tag.Equals(Owner.tag, System.StringComparison.Ordinal)))
        {
            // Make sure the owner isn't destroyed
            if (Owner != null)
                // Don't damage your owner!
                if (collision.gameObject == Owner.gameObject)
                    return;
            // Damage the character hit
            collision.gameObject.GetComponent<ACharacter>().TakeDamage(projectileDamage);
            Destroy(this.gameObject);
        }
    }
}
