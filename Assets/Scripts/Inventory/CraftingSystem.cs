using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    Inventory inventory;
    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    public bool Craft(CraftingRecipe recipe)
    {
        // Check ingredients

        foreach(Ingredient ingredient in recipe.ingredients)
        {
            if(!inventory.HasItem(
                ingredient.item,
                ingredient.amount))
            {
                Debug.Log("Missing ingredients");
                return false;
            }
        }

        // Remove ingredients

        foreach(Ingredient ingredient in recipe.ingredients)
        {
            inventory.RemoveItem(
                ingredient.item,
                ingredient.amount);
        }

        // Add result

        inventory.AddItem(
            recipe.result,
            recipe.resultAmount);

        Debug.Log(
            "Crafted " + recipe.result.itemName);
        return true;
    }
}