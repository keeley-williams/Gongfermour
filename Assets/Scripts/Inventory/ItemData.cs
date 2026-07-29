using UnityEngine;
public enum ItemType
{
    Material,
    Weapon,
    Consumable,
    Quest
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemID;

    public string itemName;

    public Sprite icon;

    public ItemType itemType;

    public bool stackable = true;

    public int maxStack = 99;
}
