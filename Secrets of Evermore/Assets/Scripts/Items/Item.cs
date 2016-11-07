using UnityEngine;
using System.Collections;

public abstract class Item
{
    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public enum ItemType
    {
        Armor,
        Weapon,
        Quest,
        Alchemy
    }

    //Item Type
    public ItemType TypeItem;
    //Amount of items
    public int Amount = 1;
    //Name of the item
    public string Name;
    //Visual item
    public VisualItem VItem;

    //-------------------
    //PUBLIC METHODS
    //--------------------

    //Constructor
    public Item(string name)
    {
        Name = name;
    }
}
