using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomizationScreen : MonoBehaviour
{
    // An event that's called whenever any item button is pressed, to change the subscribing characters' appearance
    public delegate void OnItemButtonPressed(ItemType type, Sprite spriteToEquip);
    public static OnItemButtonPressed onItemButtonPressed;

    [SerializeField] ItemsManager itemsManager = null;
    [SerializeField] Transform itemContainersRoot = null;

    [SerializeField] GameObject itemsContainerPrefab = null;

    List<CategorizedItemsContainer> itemContainers = new List<CategorizedItemsContainer>();

    void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        ShopScreen.onItemBought += OnItemBought;
        ShopScreen.onItemSold += OnItemSold;
    }

    public void Initialize()
    {
        // Will hold the items that will be added to each container
        List<Item> items = new List<Item>();
        // Create a container and populate it with the available items for each item type
        foreach (ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            CategorizedItemsContainer container = Instantiate(itemsContainerPrefab, itemContainersRoot).GetComponent<CategorizedItemsContainer>();
            itemContainers.Add(container);
            container.Initialize(type);

            // Populate with items
            items = itemsManager.GetUnlockedItems(type);
            for (int i = 0; i < items.Count; i++)
                container.AddItem(items[i]);
        }
    }

    void OnItemBought(Item item)
    {
        // Add the new item to the corresponding container
        itemContainers.Find(x => x.ItemType == item.ItemType).AddItem(item);
    }
    void OnItemSold(Item item)
    {
        // Remove the sold item from the corresponding container
        itemContainers.Find(x => x.ItemType == item.ItemType).RemoveItem(item);
    }

    void OnDisable()
    {
        ShopScreen.onItemBought -= OnItemBought;
        ShopScreen.onItemSold -= OnItemSold;
    }
}
