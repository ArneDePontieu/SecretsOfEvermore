using UnityEngine;
using System.Collections;

public class Armor : Item
{

    public float DefenceValue = 0.0f;
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

    public ArmorType TypeArmor;
}
