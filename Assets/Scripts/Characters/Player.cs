using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ACharacter
{
    // Contains the default sprites for each body part.
    [SerializeField] CustomCharacter defaultCustomChar = null;
    // Controls the look of the character preview in the customization screen
    [SerializeField] CharacterRenderer customScreenPreviewRenderer = null;

    Camera mainCam = null;
    Vector2 mousePos = Vector2.zero;

    protected override void Initialize()
    {
        base.Initialize();
        mainCam = Camera.main;
        // Make sure the character preview has the same outfit
        customScreenPreviewRenderer.EquipAll(customChar);
        // Start listening for movement input, which will be captured in Update
        Move(Vector2.zero);
    }

    void OnEnable()
    {
        CustomizationScreen.onItemButtonPressed += OnCustomizationButtonPressed;
        ShopScreen.onItemSold += OnItemSold;
    }
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (Input.GetButtonDown("Fire1"))
        {
            shootDir = mousePos - rb.position;
            Shoot();
        }

        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void EquipItem(ItemType type, Sprite sprite)
    {
        charRenderer.Equip(type, sprite);
        customScreenPreviewRenderer.Equip(type, sprite);
        customChar.ChangeSprite(type, sprite);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        // Check for player death
        if(currentHP <= 0)
        {
            // Stop the game
            Time.timeScale = 0f;
        }
    }

    void OnCustomizationButtonPressed(ItemType type, Sprite sprite)
    {
        EquipItem(type, sprite);
    }

    void OnItemSold(Item item)
    {
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
        ShopScreen.onItemSold -= OnItemSold;
    }
}
