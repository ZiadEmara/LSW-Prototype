using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ACharacter
{
    [SerializeField] int gold = 100;
    // Contains the default sprites for each body part.
    [SerializeField] CustomCharacter defaultCustomChar = null;
    // Controls the look of the character preview in the customization screen
    [SerializeField] CharacterRenderer customScreenPreviewRenderer = null;

    public int Gold { get { return gold; } }

    void Start()
    {
        Initialize();
        // Make sure the character preview has the same outfit
        customScreenPreviewRenderer.EquipAll(customChar);
    }

    void OnEnable()
    {
        CustomizationScreen.onItemButtonPressed += OnCustomizationButtonPressed;
        ShopScreen.onItemBought += OnItemBought;
        ShopScreen.onItemSold += OnItemSold;
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void SubtractGold(int amount)
    {
        gold -= amount;
    }

    public void EquipItem(ItemType type, Sprite sprite)
    {
        charRenderer.Equip(type, sprite);
        customScreenPreviewRenderer.Equip(type, sprite);
        customChar.ChangeSprite(type, sprite);
    }

    void OnCustomizationButtonPressed(ItemType type, Sprite sprite)
    {
        EquipItem(type, sprite);
    }

    void OnItemBought(Item item)
    {
        SubtractGold(item.ItemPrice);
    }

    void OnItemSold(Item item)
    {
        AddGold(item.ItemSellPrice);
        // Check if the sold item is equipped
        if (customChar.IsEquipped(item.ItemSprite))
        {
            // Equip the default sprite in that slot
            EquipItem(item.ItemType, defaultCustomChar.GetSprite(item.ItemType));
        }
    }

    void OnDisable()
    {
        CustomizationScreen.onItemButtonPressed -= OnCustomizationButtonPressed;
        ShopScreen.onItemBought -= OnItemBought;
        ShopScreen.onItemSold -= OnItemSold;
    }
}
