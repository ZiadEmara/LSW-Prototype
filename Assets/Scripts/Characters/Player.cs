using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ACharacter
{
    // For now respawn = restart game
    [SerializeField] float respawnTime = 5f;
    // Contains the default sprites for each body part.
    [SerializeField] CustomCharacter defaultCustomChar = null;
    // Controls the look of the character preview in the customization screen
    [SerializeField] CharacterRenderer customScreenPreviewRenderer = null;
    [SerializeField] GameObject interactButtonImage = null;

    // REferences the main camera to translate mouse position into world coordinates
    Camera mainCam = null;
    Vector2 mousePos = Vector2.zero;

    protected override void Initialize()
    {
        base.Initialize();
        mainCam = Camera.main;
        // Make sure the character preview has the same outfit
        customScreenPreviewRenderer.EquipAll(customChar);
    }

    void OnEnable()
    {
        CustomizationScreen.onItemButtonPressed += OnCustomizationButtonPressed;
        ShopScreen.onItemSold += OnItemSold;
    }
    void Update()
    {
        // Don't fire if it's still on cooldown
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
        if (currentHP <= 0)
        {
            // Stop the game
            Time.timeScale = 0f;
            // Respawn in a few seconds
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Show the interact button if near any interactable object
        if (collision.gameObject.tag.Equals("Interactable", System.StringComparison.Ordinal))
            interactButtonImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Hide the interact button when exiting the range of any interactable object
        if (collision.gameObject.tag.Equals("Interactable", System.StringComparison.Ordinal))
            interactButtonImage.SetActive(false);
    }

    void OnDisable()
    {
        CustomizationScreen.onItemButtonPressed -= OnCustomizationButtonPressed;
        ShopScreen.onItemSold -= OnItemSold;
    }
}
