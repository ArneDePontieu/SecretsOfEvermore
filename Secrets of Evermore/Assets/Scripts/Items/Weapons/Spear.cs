using UnityEngine;
using System.Collections;
using System;

public class Spear : Weapon
{

    public Spear(DamageType dType, float attackPower, string name) : base(dType, attackPower, name)
    {
        TypeOfWeapon = WeaponType.Spear;
    }

    //Jab
    public override void SpecialAttack()
    {
        throw new NotImplementedException();
    }

    //Basic Attack
    public override void BasicAttack()
    {

    }

}
