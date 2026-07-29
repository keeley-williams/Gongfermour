using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;

    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory =
            other.GetComponent<Inventory>();

        if(inventory == null)
            return;

        if(inventory.AddItem(item, amount))
        {
            Destroy(gameObject);
        }
    }
}
