using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UI container than holds items of a specific type.
/// </summary>
public class CategorizedItemsContainer : ItemsContainer
{
    [SerializeField] ItemType itemType = ItemType.Head;
    [SerializeField] Text itemTypeText = null;

    public ItemType ItemType { get { return itemType; } }

    public void Initialize(ItemType type)
    {
        itemType = type;
        itemTypeText.text = type.ToString();
    }
}
