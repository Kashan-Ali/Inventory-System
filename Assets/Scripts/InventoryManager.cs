using UnityEngine;
using System.Collections.Generic;
using System.IO;

public enum ItemType { Consumable, Equipment, QuestItem }
public enum Rarity { Common, Rare, Legendary }

[System.Serializable]
public class InventoryItem
{
    // item type fields.
    public string itemTypeStr;
    public string rarityStr;
    // item attribute fields.
    public int weightKg;
    public int valueCost;
}

public class InventoryManager : MonoBehaviour
{
    //  Singleton class accessor.
    public static InventoryManager Instance;

    //  Inventory Item list.
    public List<InventoryItem> inventoryItems;

    //  Currently Equipped Item.
    public InventoryItem equippedItem;

    // File path to save and load the item list
    private string filePath;

    private void Awake()
    {
        //  Singleton Design Pattern.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //  Set json file path.
        filePath = Path.Combine(Application.dataPath, "InventoryData/itemList.json");

        LoadInventory();
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }


    public void SaveInventory()
    {
        //  Save list into json file.
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    public void LoadInventory()
    {
        //  Load list if json file already save.
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }

    public void AddItemInInventory(string itemType, string rarity, int weightKg, int valueCost)
    {
        InventoryItem newItem = new InventoryItem()
        {
            itemTypeStr = itemType,
            rarityStr = rarity,
            weightKg = weightKg,
            valueCost = valueCost,
        };
        //  add item in inventory.
        inventoryItems.Add(newItem);

        SaveInventory();
    }

    public void RemoveItemFromInventory(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        InventoryItem itemToRemove = FindItemInList(itemTypeStr, rarityStr, weightKg, valueCost);
        // Remove the item if found
        if (itemToRemove != null)
        {
            inventoryItems.Remove(itemToRemove);
            SaveInventory();
        }
    }

    public void EquipItem(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        equippedItem.itemTypeStr = itemTypeStr;
        equippedItem.rarityStr = rarityStr;
        equippedItem.weightKg = weightKg;
        equippedItem.valueCost = valueCost;
    }

    public void UnEquipItem(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        if (equippedItem.itemTypeStr == itemTypeStr && equippedItem.rarityStr == rarityStr &&
            equippedItem.weightKg == weightKg && equippedItem.valueCost == valueCost)
            equippedItem = null;
    }


    public InventoryItem FindItemInList(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        // Find the item in the inventory
        return inventoryItems.Find(
            item => (item.itemTypeStr == itemTypeStr && item.rarityStr == rarityStr && item.weightKg == weightKg && item.valueCost == valueCost)
        );
    }

    // return result count of any filtered items from inventory by its category.
    public int CountItemCategory(string itemTypeStr, string rarityStr)
    {
        int count = 0;
        foreach (var item in inventoryItems)
        {
            if (item.itemTypeStr == itemTypeStr && item.rarityStr == rarityStr)
            {
                count++;
            }
        }
        return count;
    }


    // return result count of any exact same items from inventory to stack them.
    public int CountSameItem(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        int count = 0;
        foreach (var item in inventoryItems)
        {
            if (item.itemTypeStr == itemTypeStr && item.rarityStr == rarityStr && item.weightKg == weightKg && item.valueCost == valueCost)
            {
                count++;
            }
        }
        return count;
    }

}