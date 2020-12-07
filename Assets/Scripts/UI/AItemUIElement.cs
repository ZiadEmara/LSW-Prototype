using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AItemUIElement : MonoBehaviour
{
    [SerializeField] protected Text itemNameText = null;
    [SerializeField] protected Text itemPriceText = null;
    [SerializeField] protected Image itemImage = null;

    protected Button buttonComponent = null;
    protected ItemType type = ItemType.Head;

    void Awake()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnButtonPressed);
    }

    public void Initialize(Item item)
    {
        itemNameText.text = item.ItemName;
        // Items with price 0 are base items, so hide their price.
        if (item.ItemPrice == 0)
            itemPriceText.gameObject.SetActive(false);
        // Show sale price of unlocked items
        else if (item.IsUnlocked)
            itemPriceText.text = item.ItemSellPrice.ToString();
        else
            itemPriceText.text = item.ItemPrice.ToString();
        itemImage.sprite = item.ItemSprite;
        type = item.ItemType;
    }

    protected abstract void OnButtonPressed();

    #region getters
    public string GetItemName()
    {
        return itemNameText.text;
    }
    #endregion
}
