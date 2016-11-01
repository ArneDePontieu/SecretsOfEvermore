using UnityEngine;
using System.Collections;

public abstract class Weapon : Item
{

    public float AttacksPerSecond;
    public float MinDamagerPerAttack;
    public float MaxDamagerPerAttack;
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

    

}
