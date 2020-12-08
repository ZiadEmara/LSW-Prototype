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
            Destroy(this);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * projectileImpulse, ForceMode2D.Impulse);
    }
}
