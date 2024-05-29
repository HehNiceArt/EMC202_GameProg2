using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SerializableKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;
    public SerializableKeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}
public class InventorySystem : MonoBehaviour
{
    public Dictionary<int, Item> Inventory = new Dictionary<int, Item>();
    public List<SerializableKeyValuePair<int, Item>> inventoryList = new List<SerializableKeyValuePair<int, Item>>();

    public void SyncListWithDictionary()
    {
        inventoryList.Clear();
        foreach(var pair in Inventory)
        {
            inventoryList.Add(new SerializableKeyValuePair<int, Item>(pair.Key, pair.Value));
        }
    }
    public void AddItem(Item item)
    {
        //checks if a preexisting item exists in the inventory
        if (Inventory.ContainsKey(item.itemId))
        {
            var existingItem = Inventory[item.itemId];
            existingItem.quanity += item.quanity;
            Inventory[item.itemId] = existingItem;
        }
        else
        {
            Inventory.Add(item.itemId, item);
        }
        SyncListWithDictionary();
    }

    public bool RemoveItem(int itemId)
    {
        bool removed = Inventory.Remove(itemId);
        if(removed)
        {
            SyncListWithDictionary();
        }
        return removed; 
    }
    public bool CheckItem(int itemId)
    {
        return Inventory.ContainsKey(itemId);
    }
}
