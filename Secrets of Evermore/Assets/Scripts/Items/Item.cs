using UnityEngine;
using System.Collections;

public abstract class Item
{
    //Type of item
    public enum ItemType
    {
        Armor,
        Weapon,
        Food,
        Quest
    }

    //Item Type
    public ItemType TypeItem;
    //Amount of items
    public int Amount;
    //Name of the item
    public string Name;

    //-------------------
    //METHODS
    //--------------------

    public Item(string name)
    {
        Name = name;
    }

    //to create an empty item
    public Item()
    {

    }

}
