using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public enum ItemType { Consumable, Equipment, QuestItem }
    public enum Rarity { Common, Rare, Legendary }

    public ItemType itemType;
    public Rarity rarity;

    public int weightKg;
    public int valueCost;
    public Sprite icon;  
}
