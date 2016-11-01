using UnityEngine;
using System.Collections;

public abstract class Weapon : Item
{

    public float AttackPower;
    public DamageType TypeOfDamage;
    public WeaponType TypeOfWeapon;

    public enum DamageType
    {
        Magical,
        Physical
    }

    public enum WeaponType
    {
        OneHander,
        TwoHander
    }

    public Weapon(WeaponType wType, DamageType dType, float attackPower,string name):base(name)
    {
        TypeOfWeapon = wType;
        TypeOfDamage = dType;
        AttackPower = attackPower;
        TypeItem = ItemType.Weapon;
    }
}
