using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomizationScreen : MonoBehaviour
{
    [SerializeField] ItemsManager itemsManager = null;
    [SerializeField] Transform itemContainersRoot = null;

    [SerializeField] GameObject itemsContainerPrefab = null;

    List<ItemsContainer> itemContainers = new List<ItemsContainer>();

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        // Will hold the items that will be added to each container
        List<Item> items = new List<Item>();
        // Create a container and populate it with the available items for each item type
        foreach (ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            ItemsContainer container = Instantiate(itemsContainerPrefab, itemContainersRoot).GetComponent<ItemsContainer>();
            itemContainers.Add(container);
            container.Initialize(type);

            // Populate with items
            items = itemsManager.GetUnlockedItems(type);
            for (int i = 0; i < items.Count; i++)
                container.AddItem(items[i]);
        }
    }
}
