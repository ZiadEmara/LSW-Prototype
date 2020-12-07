using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationUIElement : AItemUIElement
{
    protected override void OnButtonPressed()
    {
        if (CustomizationScreen.onItemButtonPressed != null)
            CustomizationScreen.onItemButtonPressed(type, itemImage.sprite);
    }
}
