using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [Header("Item Category UI Components Fields.")]
    [SerializeField] TextMeshProUGUI _itemTypeTmp;
    [SerializeField] TextMeshProUGUI _itemRarityTmp;

    [Header("Item Attributes UI Components Fields.")]
    [SerializeField] TextMeshProUGUI _itemTotalTmp;
    [SerializeField] TextMeshProUGUI _itemWeightTmp;
    [SerializeField] TextMeshProUGUI _itemValueTmp;

    //  Main components.
    [SerializeField] ItemManager _itemManager;

    //  Main input.
    int _countResult;

    private void OnEnable()
    {
        _itemManager = GetComponent<ItemManager>();

        UIUpdata();
    }

    public void UIUpdata()
    {
        //  Display item category.
        _itemTypeTmp.text = _itemManager.ItemTypeStr;
        _itemRarityTmp.text = _itemManager.RarityStr;


        //  To filter total item of same category from Inventory.
        _countResult = InventoryManager.Instance.CountItemCategory(_itemManager.ItemTypeStr, _itemManager.RarityStr);
        //  Count number of same items.
        _itemTotalTmp.text = $"Total: {_countResult}";

        //  Display item attributes.
        _itemWeightTmp.text = $"Weight: {_itemManager.WeightKg}";
        _itemValueTmp.text = $"Value: {_itemManager.ValueCost}";
    }
}
