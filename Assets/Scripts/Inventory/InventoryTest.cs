using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryTest : MonoBehaviour
{
    public ItemData wood;
    public ItemData stone;
    public CraftingRecipe recipe;
    Inventory inventory;
    CraftingSystem craftingSystem;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        craftingSystem = GetComponent<CraftingSystem>();
    }

    private void Update()
    {
        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            inventory.AddItem(wood, 1);
            Debug.Log("Added Wood");
        }

        if(Keyboard.current.sKey.wasPressedThisFrame)
        {
            inventory.AddItem(stone, 1);
            Debug.Log("Added Stone");
        }

        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            craftingSystem.Craft(recipe);
        }

        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            inventory.DebugInventory();
        }
    }
}