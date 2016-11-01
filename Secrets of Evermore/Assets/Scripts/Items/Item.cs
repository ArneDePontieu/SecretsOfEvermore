using UnityEngine;
using System.Collections;

public abstract class Item
{
    //Type of item
    public enum ItemType
    {
        Armor,
        Weapon
    }
    public ItemType TypeItem;

    //Amount of items
    public int Amount;
}
