using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIElement : AItemUIElement
{
    protected override void OnButtonPressed()
    {
        if (ShopScreen.onItemButtonPressed != null)
            ShopScreen.onItemButtonPressed(type, GetItemName());
    }
}
