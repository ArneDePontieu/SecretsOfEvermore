using UnityEngine;
using System.Collections;

public class Armor : Item
{

    public float DefenceValue;
    public ArmorType TypeArmor;

    public enum ArmorType
    {
        Head,
        Shoulder,
        Chest,
        Wrist,
        Gloves,
        Pants,
        Boots,
        Belt
    }

    //--------------------
    //METHODS
    //--------------------

    public Armor(float defenceValue,string name, ArmorType type):base(name)
    {
        DefenceValue = defenceValue;
        TypeItem = ItemType.Armor;
        TypeArmor = type;
    }

}
