using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ACharacter
{
    // The target that this enemy is focusing
    Transform target = null;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

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
                // Stop moving and shoot the player
                StopMoving();
                shootDir = (Vector2)target.position - rb.position;
                Shoot();
                MoveRand();
            }
        }
    }

    // Moves in a random direction
    void MoveRand()
    {
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Move(dir);
    }
}
