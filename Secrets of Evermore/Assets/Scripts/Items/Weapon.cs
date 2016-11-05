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
        Axe,
        Spear,
        Sword            
    }

    public Weapon(DamageType dType, float attackPower,string name):base(name)
    {
        TypeOfDamage = dType;
        AttackPower = attackPower;
        TypeItem = ItemType.Weapon;
    }

    public abstract void BasicAttack();
    public abstract void SpecialAttack();
}
