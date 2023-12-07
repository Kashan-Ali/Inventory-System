using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemType _itemType;
    [SerializeField] Rarity _rarity;
    [SerializeField] int _weightKg;
    [SerializeField] int _valueCost;

    //  Logical condition for system modularity if it use in runtime 3D space.
    enum MultipleAdded { Yes, No }
    [SerializeField] MultipleAdded _addMultiTimes;
    enum DestroyItemAterInteract { No, Yes }
    [SerializeField] DestroyItemAterInteract _destroyItemAterInteract;
    enum InteractOutsideInventory { No, Yes }
    [SerializeField] InteractOutsideInventory _interactOutsideInventory;

    //  Poperties to Share item Categories.
    public string ItemTypeStr { get { return _itemTypeStr; } }
    public string RarityStr { get { return _rarityStr; } }
    //  Poperties to Share item attributes.
    public int WeightKg { get { return _weightKg; } }
    public int ValueCost { get { return _valueCost; } }

    //  private Canditions fields.
    bool _itemAdded = false;
    [SerializeField] bool _itemEquipped = false;

    //  Main item category Input fields.
    string _itemTypeStr;
    string _rarityStr;

    private void OnEnable()
    {
        AssignItemTypeAndRarity();
        // A simple logic to demonstrate that if object destroyed after interaction so, how we can add it again.
        if (_addMultiTimes == MultipleAdded.Yes)
            _destroyItemAterInteract = DestroyItemAterInteract.No;

        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            _addMultiTimes = MultipleAdded.No;
    }

    /*
    //  For testing purpuse.
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
    */

    void AssignItemTypeAndRarity()
    {
        switch (_itemType)
        {
            case ItemType.Consumable:
                _itemTypeStr = "Consumable";
                break;

            case ItemType.Equipment:
                _itemTypeStr = "Equipment";
                break;

            case ItemType.QuestItem:
                _itemTypeStr = "QuestItem";
                break;
        }

        switch (_rarity)
        {
            case Rarity.Common:
                _rarityStr = "Common";
                break;

            case Rarity.Rare:
                _rarityStr = "Rare";
                break;

            case Rarity.Legendary:
                _rarityStr = "Legendary";
                break;
        }
    }

    public void AddItem()
    {
        if (_addMultiTimes == MultipleAdded.No && _itemAdded == true)
            return;

        _itemAdded = true;

        AssignItemTypeAndRarity();
        InventoryManager.Instance.AddItemInInventory(_itemTypeStr, _rarityStr, _weightKg, _valueCost);

        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes && _addMultiTimes == MultipleAdded.No)
            Destroy(gameObject);
    }

    public void RemoveItem()
    {
        if (_itemType == ItemType.Equipment && _itemEquipped == true)
            return;

        AssignItemTypeAndRarity();
        InventoryManager.Instance.RemoveItemFromInventory(_itemTypeStr, _rarityStr, _weightKg, _valueCost);
    }

    public void ConsumeItem()
    {
        AssignItemTypeAndRarity();

        if (_itemType != ItemType.Consumable)
            return;

        if (_interactOutsideInventory == InteractOutsideInventory.No)
        {
            // Find the item in the inventory
            InventoryItem item = InventoryManager.Instance.FindItemInList(_itemTypeStr, _rarityStr, _weightKg, _valueCost);

            // terminating method execution.
            if (item == null)
                return;
        }
        // code underneath from here.

        /// Write your code here.





        // end your code above.

        RemoveItem();
        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            Destroy(gameObject);
    }

    public void EquipItem()
    {
        AssignItemTypeAndRarity();

        if (_itemType != ItemType.Equipment)
            return;
        _itemEquipped = true;

        if (_interactOutsideInventory == InteractOutsideInventory.No)
        {
            // Find the item in the inventory
            InventoryItem item = InventoryManager.Instance.FindItemInList(_itemTypeStr, _rarityStr, _weightKg, _valueCost);

            // terminating method execution.
            if (item == null)
                return;
        }
        // code underneath from here.

        /// Write your code here.





        // end your code above.
    }

    public void UseItem()
    {
        AssignItemTypeAndRarity();

        if (_itemType != ItemType.QuestItem)
            return;

        if (_interactOutsideInventory == InteractOutsideInventory.No)
        {
            // Find the item in the inventory
            InventoryItem item = InventoryManager.Instance.FindItemInList(_itemTypeStr, _rarityStr, _weightKg, _valueCost);

            // terminating method execution.
            if (item == null)
                return;
        }
        // code underneath from here.

        /// Write your code here.






        // end your code above.

        RemoveItem();
        if (_destroyItemAterInteract == DestroyItemAterInteract.Yes)
            Destroy(gameObject);
    }
}
