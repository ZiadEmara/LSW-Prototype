﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Parent class for any character, whether it's an ally or enemy
/// </summary>
public abstract class ACharacter : MonoBehaviour
{
    [SerializeField] protected CustomCharacter customChar = null;
    [SerializeField] protected CharacterRenderer charRenderer = null;
    [SerializeField] protected GameObject projectile = null;
    [SerializeField] Image healthBar = null;
    [SerializeField] protected int maxHP = 100;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected float atkSpeed = 1f;

    protected int currentHP = 0;
    protected Rigidbody2D rb = null;
    protected bool move = false;
    protected Vector2 moveDir = Vector2.zero;
    protected Vector2 shootDir = Vector2.zero;

    protected float timer = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        charRenderer.EquipAll(customChar);
        currentHP = maxHP;
        healthBar.fillAmount = 1f;
    }

    // Only move when this is called. Used mainly when enemies keep moving and stopping.
    protected void Move(Vector2 dir)
    {
        move = true;
        moveDir = dir;
    }

    protected void StopMoving()
    {
        move = false;
    }

    protected void Shoot()
    {
        Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg);
        Projectile shot = Instantiate(projectile, transform.position, rot).GetComponent<Projectile>();
        shot.Owner = this;
        // Put shooting on cooldown
        timer = 1 / atkSpeed;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;
        healthBar.fillAmount = (float)currentHP / (float)maxHP;
    }

    void FixedUpdate()
    {
        if (move)
        {
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
