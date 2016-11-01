using UnityEngine;
using System.Collections;

public abstract class Item
{

    public enum ItemType
    {
        Armor,
        Weapon
    }
    public ItemType TypeItem;
    public int Amount;

    public Item() { }

}
