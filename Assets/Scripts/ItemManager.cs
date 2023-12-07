using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemType itemType;
    public Rarity rarity;

    public int weightKg;
    public int valueCost;

    enum MultipleAdded { Yes, No }
    [SerializeField] MultipleAdded _addMultiTimes;
    enum DestroyItemAterInteract { No, Yes }
    [SerializeField] DestroyItemAterInteract _destroyItemAterInteract;
    enum InteractOutsideInventory { No, Yes }
    [SerializeField] InteractOutsideInventory _interactOutsideInventory;

    //  private Canditions fields.
    [SerializeField] bool _itemAdded = false;
    [SerializeField] bool _itemEquipped = false;

    //  private item category fields.
    string itemTypeStr;
    string rarityStr;

    private void OnEnable()
    {
        if (_addMultiTimes == MultipleAdded.Yes)
            _destroyItemAterInteract = DestroyItemAterInteract.No;

        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            _addMultiTimes = MultipleAdded.No;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AddItem();

        if (Input.GetKeyDown(KeyCode.E))
            RemoveItem();

        if (Input.GetKeyDown(KeyCode.C))
            ConsumeItem();

        if (Input.GetKeyDown(KeyCode.X))
            EquipItem();

        if (Input.GetKeyDown(KeyCode.Z))
            UseItem();
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
        if (_addMultiTimes == MultipleAdded.No && _itemAdded == true)
            return;

        _itemAdded = true;

        AssignItemTypeAndRarity();
        InventoryManager.Instance.AddItemInInventory(itemTypeStr, rarityStr, weightKg, valueCost);

        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes && _addMultiTimes == MultipleAdded.No)
            Destroy(gameObject);
    }

    public void RemoveItem()
    {
        if (itemType == ItemType.Equipment && _itemEquipped == true)
            return;

        AssignItemTypeAndRarity();
        InventoryManager.Instance.RemoveItemFromInventory(itemTypeStr, rarityStr, weightKg, valueCost);
    }

    public void ConsumeItem()
    {
        if (_interactOutsideInventory == InteractOutsideInventory.No)
        {
            // Find the item in the inventory
            InventoryItem item = InventoryManager.Instance.FindItemInList(itemTypeStr, rarityStr, weightKg, valueCost);

            // terminating method execution.
            if (item == null)
                return;
        }


        if (itemType != ItemType.Consumable)
            return;

        AssignItemTypeAndRarity();


        // code underneath from here.





        // end your code above.

        RemoveItem();
        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            Destroy(gameObject);
    }

    public void EquipItem()
    {
        if (itemType != ItemType.Equipment)
            return;
        _itemEquipped = true;

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
        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            Destroy(gameObject);
    }
}
