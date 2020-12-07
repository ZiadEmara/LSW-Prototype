using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] string itemName = string.Empty;
    [SerializeField] int itemPrice = 0;
    [SerializeField] Sprite itemSprite = null;
    [SerializeField] bool isUnlocked = false;
    [SerializeField] ItemType itemType = ItemType.Head;

    public string ItemName { get { return itemName; } }
    public int ItemPrice { get { return itemPrice; } }
    public Sprite ItemSprite { get { return itemSprite; } }
    public bool IsUnlocked { get { return isUnlocked; } set { isUnlocked = value; } }
    public ItemType ItemType { get { return itemType; } }
}
