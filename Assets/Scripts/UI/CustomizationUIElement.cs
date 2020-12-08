using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI elements of the customization screen
/// </summary>
public class CustomizationUIElement : AItemUIElement
{
    protected override void OnButtonPressed()
    {
        if (CustomizationScreen.onItemButtonPressed != null)
            CustomizationScreen.onItemButtonPressed(type, itemImage.sprite);
    }
}
