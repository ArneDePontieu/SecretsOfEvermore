using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{

    //PRIVATE  VARIABLES
    private bool IsInvFull = false;

    //PUBLIC VARIABLES
    public List<Item> ItemList = new List<Item>();

    //PUBLIC METHODS

    public void Initialize()
    {
        AddItem(new Sword(Weapon.DamageType.Physical, 10, "Standard Axe"));
        AddItem(new Armor(1, "Leather Helm", Armor.ArmorType.Head));
        AddItem(new Armor(1, "Leather Shoulderpads", Armor.ArmorType.Shoulder));
        AddItem(new Armor(1, "Leather Chest", Armor.ArmorType.Chest));
        AddItem(new Armor(1, "Leather Gloves", Armor.ArmorType.Gloves));
        AddItem(new Armor(1, "Leather Wrist", Armor.ArmorType.Wrist));
        AddItem(new Armor(1, "Leather Pants", Armor.ArmorType.Pants));
        AddItem(new Armor(1, "Leather Boots", Armor.ArmorType.Boots));
        AddItem(new Armor(1, "Leather Belt", Armor.ArmorType.Belt));
    }

    public Weapon GetWeapon()
    {
        foreach (var item in ItemList)
        {
            if (item.TypeItem == Item.ItemType.Weapon)
            {
                return item as Weapon;
            }
        }

        return new Sword(Weapon.DamageType.Physical, 1.0f, "Wooden Sword") as Weapon;
    }

    public bool AddItem(Item item)
    {
        //Check the inventory to see if you found an upgrade
        if (item.TypeItem == Item.ItemType.Armor || item.TypeItem == Item.ItemType.Weapon)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                //Do something depending on what the item is
                switch (item.TypeItem)
                {
                    //What to do if it's a weapon
                    case Item.ItemType.Weapon:
                        if (ItemList[i].TypeItem == Item.ItemType.Weapon)
                        {
                            var weaponFound = item as Weapon;
                            var weaponInInv = ItemList[i] as Weapon;

                            if (weaponInInv.AttackPower < weaponFound.AttackPower)
                            {
                                ItemList[i] = item;
                                return true;
                            }
                        }
                        break;
                    //What to do if it's armor
                    case Item.ItemType.Armor:
                        if (ItemList[i].TypeItem == Item.ItemType.Armor)
                        {
                            var armorFound = item as Armor;
                            var armorInInv = ItemList[i] as Armor;

                            if ((armorInInv.DefenceValue < armorFound.DefenceValue) && (armorFound.TypeArmor == armorInInv.TypeArmor))
                            {
                                ItemList[i] = item;
                                return true;
                            }
                        }
                        break;
                }
            }

            GameManager.Instance.CharManagerInstance.UpdateCharacterStats();
        }

        //Check if the inventory is full
        if (!IsInvFull)
        {
            ItemList.Add(item);
            return true;
        }

        //Set the inventory full
        if (ItemList.Count >= GameManager.Instance.UIManagerInstance.InvPanel.InventorySize)
        {
            IsInvFull = true;
        }

        return false;
    }

    public void RemoveItem(Item item)
    {
        //Remove an item from the list
        ItemList.Remove(item);
        IsInvFull = false;
    }

    public void RemoveItem(string itemName)
    {
        //Remove an item from the list
        foreach (var item in ItemList)
        {
            if (item.Name == itemName)
            {
                ItemList.Remove(item);
                break;
            }
        }
        IsInvFull = false;
    }

    //Check if you haave an item in your inventory
    public bool CheckForItem(string name)
    {
        foreach (var item in ItemList)
        {
            if (item.Name == name)
            {
                return true;
            }
        }

        return false;
    }

}
