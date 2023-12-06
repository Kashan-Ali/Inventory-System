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

//  Divid item into categories.
[System.Serializable]
public class ConsumableItem
{
    // item type fields.
    public string rarityStr;
    // item attribute fields.
    public int weightKg;
    public int valueCost;

    public int totalCommon = 0;
    public int totalRare = 0;
    public int totalLegendary = 0;
}
[System.Serializable]
public class EquipmentItem
{
    // item type fields.
    public string rarityStr;
    // item attribute fields.
    public int weightKg;
    public int valueCost;

    public int totalCommon = 0;
    public int totalRare = 0;
    public int totalLegendary = 0;
}
[System.Serializable]
public class QuestItemItem
{
    // item type fields.
    public string rarityStr;
    // item attribute fields.
    public int weightKg;
    public int valueCost;

    public int totalCommon = 0;
    public int totalRare = 0;
    public int totalLegendary = 0;
}


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> inventoryItems;

    // File path to save and load the item list
    private string filePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Path.Combine(Application.dataPath, "InventoryData/itemList.json");
    }

    private void Start()
    {
        LoadInventory();
    }

    private void OnApplicationQuit()
    {
        SaveInventory();
    }


    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }

    public void LoadInventory()
    {
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

    public InventoryItem FindItemInList(string itemTypeStr, string rarityStr, int weightKg, int valueCost)
    {
        // Find the item in the inventory
        return inventoryItems.Find(
            item => (item.itemTypeStr == itemTypeStr && item.rarityStr == rarityStr && item.weightKg == weightKg && item.valueCost == valueCost)
        );
    }
}