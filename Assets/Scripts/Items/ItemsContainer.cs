using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UI container than holds items of the same type in the shop or customization screen
/// </summary>
public class ItemsContainer : MonoBehaviour
{
    [SerializeField] ItemType itemType = ItemType.Head;
    [SerializeField] Text itemTypeText = null;

    [SerializeField] GameObject itemUIElementPrefab = null;

    List<ItemUIElement> items = new List<ItemUIElement>();

    public ItemType ItemType { get { return itemType; } }

    public void Initialize(ItemType type)
    {
        itemType = type;
        itemTypeText.text = type.ToString();
    }

    public void AddItem(Item item)
    {
        ItemUIElement itemUI = Instantiate(itemUIElementPrefab, this.transform).GetComponent<ItemUIElement>();
        items.Add(itemUI);
        itemUI.Initialize(item);
    }
}
