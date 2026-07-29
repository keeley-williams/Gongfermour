using UnityEngine;

[CreateAssetMenu(fileName="New Recipe", menuName="Inventory/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public ItemData result;
    public int resultAmount = 1;
    public Ingredient[] ingredients;
}

[System.Serializable]
public class Ingredient
{
    public ItemData item;
    public int amount;
}