using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ACharacter
{
    // Fired when any enemy dies
    public delegate void OnEnemyDeath(Enemy enemy);
    public static OnEnemyDeath onEnemyDeath;

    [SerializeField] int goldReward = 20;

    // The target that this enemy is focusing
    Transform target = null;

    public int GoldReward { get { return goldReward; } }

    protected override void Start()
    {
        base.Start();
        // As soon as enemies spawn, they should move
        // Put their shooting on cooldown
        timer = 1 / atkSpeed;
        MoveRand();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // Shoot at the player
                shootDir = (Vector2)target.position - rb.position;
                Shoot();
                MoveRand();
            }
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (currentHP <= 0)
        {
            onEnemyDeath(this);
        }
    }

    // Moves in a random direction
    void MoveRand()
    {
        moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
