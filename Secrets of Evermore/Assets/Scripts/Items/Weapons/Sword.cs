using UnityEngine;
using System.Collections;
using System;

public class Sword : Weapon
{

    public Sword(DamageType dType, float attackPower, string name) : base(dType, attackPower, name)
    {
        TypeOfWeapon = WeaponType.Sword;
    }

    //Cleave attack
    public override void SpecialAttack()
    {
        //Hit everything in cone

        //Calculate the angle between the forward vector and the vector to the enemy, damage the enemies in the cone
        foreach (var enemy in GameManager.Instance.CharManagerInstance.EnemyList.ToArray())
        {
            var angle = Vector3.Angle(GameManager.Instance.CharManagerInstance.GetSelectedCharacter().VCharacter.ForwardVector, -GameManager.Instance.CharManagerInstance.VectorFromSelectedChar(enemy.VEnemy));
            if (angle <= 45.0f && GameManager.Instance.CharManagerInstance.VectorFromSelectedChar(enemy.VEnemy).magnitude <= 3.0f)

            {
                enemy.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage() * 0.75f);
            }
        }
    }

}
