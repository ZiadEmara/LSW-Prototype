using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UI container than holds items of any type.
/// </summary>
public class ItemsContainer : MonoBehaviour
{
    [SerializeField] GameObject itemUIElementPrefab = null;

    List<AItemUIElement> items = new List<AItemUIElement>();

    public void AddItem(Item item)
    {
        AItemUIElement itemUI = Instantiate(itemUIElementPrefab, this.transform).GetComponent<AItemUIElement>();
        items.Add(itemUI);
        itemUI.Initialize(item);
    }

    public void RemoveItem(Item item)
    {
        AItemUIElement itemToRemove = items.Find(x => x.GetItemName().Equals(item.ItemName, System.StringComparison.Ordinal));
        items.Remove(itemToRemove);
        Destroy(itemToRemove.gameObject);
    }
}
