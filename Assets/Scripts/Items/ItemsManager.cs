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

    void OnEnable()
    {
        ShopScreen.onItemBought += OnItemBought;
        ShopScreen.onItemSold += OnItemSold;
    }

    public List<Item> GetUnlockedItems()
    {
        return allItems.FindAll(x => x.IsUnlocked == true);
    }
    public List<Item> GetUnlockedItems(ItemType type)
    {
        return allItems.FindAll(x => x.ItemType == type && x.IsUnlocked == true);
    }
    public List<Item> GetLockedItems()
    {
        return allItems.FindAll(x => x.IsUnlocked == false);
    }
    public List<Item> GetLockedItems(ItemType type)
    {
        return allItems.FindAll(x => x.ItemType == type && x.IsUnlocked == false);
    }
    public Item GetItem(string itemName)
    {
        return allItems.Find(x => x.ItemName.Equals(itemName, System.StringComparison.Ordinal));
    }
    void UnlockItem(string itemName)
    {
        allItems.Find(x => x.ItemName.Equals(itemName, System.StringComparison.Ordinal)).IsUnlocked = true;
    }
    void LockItem(string itemName)
    {
        allItems.Find(x => x.ItemName.Equals(itemName, System.StringComparison.Ordinal)).IsUnlocked = false;
    }

    void OnItemBought(Item item)
    {
        UnlockItem(item.ItemName);
    }
    void OnItemSold(Item item)
    {
        LockItem(item.ItemName);
    }

    void OnDisable()
    {
        ShopScreen.onItemBought -= OnItemBought;
        ShopScreen.onItemSold -= OnItemSold;
    }
}
