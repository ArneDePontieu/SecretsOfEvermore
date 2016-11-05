using UnityEngine;
using System.Collections;
using System;

public class Sword : Weapon {

    public Sword(DamageType dType, float attackPower, string name) : base( dType, attackPower, name)
    {
        TypeOfWeapon = WeaponType.Sword;
    }

    //Slash attack
    public override void SpecialAttack()
    {
        throw new NotImplementedException();
    }

    //Basic attack
    public override void BasicAttack()
    {
        throw new NotImplementedException();
    }
}
