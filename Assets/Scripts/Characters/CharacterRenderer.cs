using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls all the Sprite renderers for the character that this is attached to
/// </summary>
public class CharacterRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer head = null;
    [SerializeField] SpriteRenderer top = null;
    [SerializeField] SpriteRenderer bottom = null;
    [SerializeField] SpriteRenderer main = null;
    [SerializeField] SpriteRenderer sub = null;

    public void EquipAll(CustomCharacter character)
    {
        EquipHead(character.HeadSprite);
        EquipTop(character.TopSprite);
        EquipBottom(character.BottomSprite);
        EquipMain(character.MainSprite);
        EquipSub(character.SubSprite);
    }

    public void Equip(ItemType type, Sprite sprite)
    {
        if (type == ItemType.Head)
            EquipHead(sprite);
        else if (type == ItemType.Top)
            EquipTop(sprite);
        else if (type == ItemType.Bottom)
            EquipBottom(sprite);
        else if (type == ItemType.Main)
            EquipMain(sprite);
        else if (type == ItemType.Sub)
            EquipSub(sprite);
    }

    void EquipHead(Sprite newSprite)
    {
        head.sprite = newSprite;
    }
    void EquipTop(Sprite newSprite)
    {
        top.sprite = newSprite;
    }
    void EquipBottom(Sprite newSprite)
    {
        bottom.sprite = newSprite;
    }
    void EquipMain(Sprite newSprite)
    {
        main.sprite = newSprite;
    }
    void EquipSub(Sprite newSprite)
    {
        sub.sprite = newSprite;
    }
}
