using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> items = new();
    public int maxSlots = 20;

    public bool AddItem(ItemData item, int amount)
    {
        if (item == null)
        {
            Debug.LogWarning("Tried to add a null item.");
            return false;
        }
        
        // Try to stack the item if it already exists
        if (item.stackable)
        {
            InventorySlot existingSlot = items.Find(x => x.item == item);

            if (existingSlot != null)
            {
                existingSlot.amount += amount;
                return true;
            }
        }

        // Check if inventory is full
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventory Full");
            return false;
        }
        // Create a new inventory slot
        items.Add(new InventorySlot(item, amount));

        return true;
    }

    public bool HasItem(ItemData item, int amount)
    {
        InventorySlot slot = items.Find(x => x.item == item);

        if (slot == null)
            return false;

        return slot.amount >= amount;
    }

    public void RemoveItem(ItemData item, int amount)
    {
        InventorySlot slot = items.Find(x => x.item == item);

        if (slot == null)
            return;

        slot.amount -= amount;

        if (slot.amount <= 0)
        {
            items.Remove(slot);
        }
    }

    public void DebugInventory()
    {
        if (items.Count == 0)
        {
            Debug.Log("Inventory is empty");
            return;
        }

        Debug.Log("----- INVENTORY -----");

        foreach (InventorySlot slot in items)
        {
            Debug.Log(
                slot.item.itemName + " x" + slot.amount
            );
        }

        Debug.Log("---------------------");
    }
}