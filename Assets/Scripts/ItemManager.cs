using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    public ItemType itemType;
    public Rarity rarity;

    public int weightKg;
    public int valueCost;

    string itemTypeStr;
    string rarityStr;
    
    bool _itemAdded = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AddItem();

        if (Input.GetKeyDown(KeyCode.E))
            RemoveItem();
    }

    void AssignItemTypeAndRarity()
    {
        switch (itemType)
        {
            case ItemType.Consumable:
                itemTypeStr = "Consumable";
                break;

            case ItemType.Equipment:
                itemTypeStr = "Equipment";
                break;

            case ItemType.QuestItem:
                itemTypeStr = "QuestItem";
                break;
        }

        switch (rarity)
        {
            case Rarity.Common:
                rarityStr = "Common";
                break;

            case Rarity.Rare:
                rarityStr = "Rare";
                break;

            case Rarity.Legendary:
                rarityStr = "Legendary";
                break;
        }
    }

    public void AddItem()
    {
        if (_itemAdded)
            return;

        AssignItemTypeAndRarity();

        _itemAdded = true;
        InventoryManager.Instance.AddItem(itemTypeStr, rarityStr, weightKg, valueCost);

    }

    public void RemoveItem()
    {
        AssignItemTypeAndRarity();

        InventoryManager.Instance.RemoveItem(itemTypeStr, rarityStr, weightKg, valueCost);
    }

    public void ConsumeItem()
    {
        if (itemType != ItemType.Consumable)
            return;

        AssignItemTypeAndRarity();

        // code underneath from here.





        // end your code above.

        RemoveItem();
    }

    public void EquipItem()
    {
        if (itemType != ItemType.Consumable)
            return;

        AssignItemTypeAndRarity();

        // code underneath from here.





        // end your code above.
    }

    public void UseItem()
    {
        if (itemType != ItemType.QuestItem)
            return;

        AssignItemTypeAndRarity();

        // code underneath from here.





        // end your code above.

        RemoveItem();
    }
}
