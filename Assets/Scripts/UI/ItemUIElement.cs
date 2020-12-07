using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIElement : MonoBehaviour
{
    [SerializeField] Text itemNameText = null;
    [SerializeField] Text itemPriceText = null;
    [SerializeField] Image itemImage = null;

    public void Initialize(Item item)
    {
        itemNameText.text = item.ItemName;
        if (item.IsUnlocked || item.ItemPrice == 0)
            itemPriceText.gameObject.SetActive(false);
        else
            itemPriceText.text = item.ItemPrice.ToString();
        itemImage.sprite = item.ItemSprite;
    }
}
