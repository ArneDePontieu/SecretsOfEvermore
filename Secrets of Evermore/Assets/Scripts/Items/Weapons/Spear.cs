using UnityEngine;
using System.Collections;
using System;

public class Spear : Weapon
{

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Constructor
    public Spear(DamageType dType, float attackPower, string name) : base(dType, attackPower, name)
    {
        TypeOfWeapon = WeaponType.Spear;
    }

    //Throw spear
    public override void SpecialAttack()
    {
        //Do a raycast to check if an enemy is in front of you
        RaycastHit2D hit = Physics2D.Raycast(
            GameManager.Instance.CharManagerInstance.GetSelectedCharacter().VCharacter.transform.position,
            GameManager.Instance.CharManagerInstance.GetSelectedCharacter().VCharacter.ForwardVector,
            5.0f,
            LayerMask.GetMask("EnemyLayer"));

        if (hit.collider != null)
        {
            //Hit the enemy with standard damage
            if (hit.collider.gameObject.tag == "Enemy" && hit.distance <= 3.0f)
            {
                hit.collider.gameObject.GetComponent<VisualEnemy>().Info.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage() * 0.75f);
            }
        }
    }
}
