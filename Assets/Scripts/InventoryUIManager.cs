using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] List<GameObject> itemIcons;

    private void OnEnable()
    {
        ItemIconEnabler();
    }

    private void Update()
    {
        //  ItemIconEnabler();
    }

    void ItemIconEnabler()
    {
        for (int i = 0; i < InventoryManager.Instance.inventoryItems.Count; i++)
        {
            itemIcons[i].SetActive(true);
        }
        for (int i = InventoryManager.Instance.inventoryItems.Count; i < itemIcons.Count; i++)
        {
            itemIcons[i].SetActive(false);
        }
    }
}
