using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Resources/Item", order = 1)]
public class SO_Item : ScriptableObject
{
    public ItemType ItemType;
    public int Amount;
    public Sprite Image;
    public string Name;
}

public enum ItemType
{
    Shield,
    Weapon,
    Coin
}
