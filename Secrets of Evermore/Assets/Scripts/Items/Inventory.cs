using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{

    private bool IsInvFull = false;
    public List<Item> ItemList = new List<Item>();

    public void Initialize()
    {
        //AddItem(new Spear(Weapon.WeaponType.OneHander,Weapon.DamageType.Physical,10,"SuperSpear"));
        //AddItem(new Spear(Weapon.WeaponType.OneHander, Weapon.DamageType.Physical, 10, "SuperSpear"));
        AddItem(new Armor(5,"SuperChest",Armor.ArmorType.Chest));
    }

    public void AddItem(Item item)
    {
        //Check if the inventory is full
        if (!IsInvFull)
        {
            ItemList.Add(item);
        }

        //Set the inventory full
        if (ItemList.Count >= GameManager.Instance.UIManagerInstance.InvPanel.InventorySize)
        {
            IsInvFull = true;
        }
    }

    public void RemoveItem(Item item)
    {
        //Remove an item from the list
        ItemList.Remove(item);
        IsInvFull = false;
    }
}
