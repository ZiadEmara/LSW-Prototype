using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    // An event that's called whenever any item button is pressed. Fires the buy or sell events.
    public delegate void OnItemButtonPressed(ItemType type, string itemName);
    public static OnItemButtonPressed onItemButtonPressed;

    public delegate void OnItemBought(Item item);
    public static OnItemBought onItemBought;

    public delegate void OnItemSold(Item item);
    public static OnItemSold onItemSold;

    [SerializeField] ItemsManager itemsManager = null;
    [SerializeField] ItemsContainer buyListContainer = null;
    [SerializeField] ItemsContainer sellListContainer = null;
    [SerializeField] Text shopStatusText = null;

    void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        onItemButtonPressed += OnShopItemButtonPressed;
    }

    public void Initialize()
    {
        // Will hold the items that will be added to each container
        List<Item> items = new List<Item>();
        // Populate the Buy and Sell lists.
        items = itemsManager.GetLockedItems();
        for (int i = 0; i < items.Count; i++)
            buyListContainer.AddItem(items[i]);

        items = itemsManager.GetUnlockedItems();
        for (int i = 0; i < items.Count; i++)
        {
            // Don't add items with sell price 0
            if (items[i].ItemSellPrice != 0)
                sellListContainer.AddItem(items[i]);
        }
    }

    void OnShopItemButtonPressed(ItemType type, string itemName)
    {
        Item item = itemsManager.GetItem(itemName);
        if (buyListContainer.gameObject.activeInHierarchy)
        {
            // Means that an item was bought since the "buy list" is active.
            // Remove item from the "buy list" and add it to the "sell list"
            buyListContainer.RemoveItem(item);
            sellListContainer.AddItem(item);
            // Update the status text
            shopStatusText.text = "Purchase Success!";
            // Fire the "item bought" event
            if (onItemBought != null)
                onItemBought(item);
        }
        else if (sellListContainer.gameObject.activeInHierarchy)
        {
            // Means that an item was sold since the "sell list" is active.
            // Remove item from the "sell list" and add it to the "buy list"
            sellListContainer.RemoveItem(item);
            buyListContainer.AddItem(item);
            // Update the status text
            shopStatusText.text = "Item Sold!";
            // Fire the "item sold" event
            if (onItemSold != null)
                onItemSold(item);
        }
    }

    void OnDisable()
    {
        onItemButtonPressed -= OnShopItemButtonPressed;
    }
}
