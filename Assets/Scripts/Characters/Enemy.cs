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
}
