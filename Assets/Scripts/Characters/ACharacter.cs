using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class for any character, whether it's an ally or enemy
/// </summary>
public abstract class ACharacter : MonoBehaviour
{
    [SerializeField] protected CustomCharacter customChar = null;
    [SerializeField] protected CharacterRenderer charRenderer = null;
    [SerializeField] protected int maxHP = 100;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected float atkSpeed = 1f;

    protected int currentHP = 0;

    public void Initialize()
    {
        charRenderer.EquipAll(customChar);
        currentHP = maxHP;
    }
}
