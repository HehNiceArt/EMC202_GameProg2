using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    public string itemName;
    public int itemId;
    public int quantity;

    InventorySystem inventorySystem;

    private void Start()
    {
        inventorySystem = GameObject.FindWithTag("Player").GetComponent<InventorySystem>();
    }

    public void CollectItem()
    {
        Item itemToAdd = new Item(itemName, itemId, quantity);
        inventorySystem.AddItem(itemToAdd); 
        Destroy(gameObject);
    }
}