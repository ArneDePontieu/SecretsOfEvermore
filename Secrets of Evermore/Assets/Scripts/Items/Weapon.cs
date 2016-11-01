using UnityEngine;
using System.Collections;

public abstract class Weapon : Item
{

    public float AttacksPerSecond;
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

    public Weapon(WeaponType wType, DamageType dType)
    {
        TypeOfWeapon = wType;
        TypeOfDamage = dType;
    }
}
