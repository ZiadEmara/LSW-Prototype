using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Central place for all available items
/// </summary>
public class ItemsManager : MonoBehaviour
{
    [SerializeField] List<Item> allItems = null;

    public List<Item> GetUnlockedItems(ItemType type)
    {
        return allItems.FindAll(x => x.ItemType == type && x.IsUnlocked == true);
    }

    public List<Item> GetLockedItems(ItemType type)
    {
        return allItems.FindAll(x => x.ItemType == type && x.IsUnlocked == false);
    }
}
