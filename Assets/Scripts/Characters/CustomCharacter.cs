using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all the character appearance related info, mainly the sprites equiped in each slot
/// </summary>
[CreateAssetMenu(fileName = "CustomCharacter", menuName = "ScriptableObjects/CustomCharacter", order = 1)]
public class CustomCharacter : ScriptableObject
{
    [SerializeField] Sprite headSprite = null;
    [SerializeField] Sprite topSprite = null;
    [SerializeField] Sprite bottomSprite = null;
    [SerializeField] Sprite mainSprite = null;
    [SerializeField] Sprite subSprite = null;

    public Sprite HeadSprite { get { return headSprite; } set { headSprite = value; } }
    public Sprite TopSprite { get { return topSprite; } set { topSprite = value; } }
    public Sprite BottomSprite { get { return bottomSprite; } set { bottomSprite = value; } }
    public Sprite MainSprite { get { return mainSprite; } set { mainSprite = value; } }
    public Sprite SubSprite { get { return subSprite; } set { subSprite = value; } }

    public void ChangeSprite(ItemType type, Sprite sprite)
    {
        if (type == ItemType.Head)
            HeadSprite = sprite;
        else if (type == ItemType.Top)
            TopSprite = sprite;
        else if (type == ItemType.Bottom)
            BottomSprite = sprite;
        else if (type == ItemType.Main)
            MainSprite = sprite;
        else if (type == ItemType.Sub)
            SubSprite = sprite;
    }

    // Returns the sprite currently equipped in the specified slot
    public Sprite GetSprite(ItemType type)
    {
        if (type == ItemType.Head)
            return HeadSprite;
        else if (type == ItemType.Top)
            return TopSprite;
        else if (type == ItemType.Bottom)
            return BottomSprite;
        else if (type == ItemType.Main)
            return MainSprite;
        else if (type == ItemType.Sub)
            return SubSprite;
        else
            return null;
    }

    public bool IsEquipped(Sprite sprite)
    {
        if (headSprite == sprite || TopSprite == sprite || BottomSprite == sprite || MainSprite == sprite || SubSprite == sprite)
            return true;

        return false;
    }
}
