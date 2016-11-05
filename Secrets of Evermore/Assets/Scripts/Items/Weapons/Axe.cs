using UnityEngine;
using System.Collections;

public class Axe : Weapon
{

    public Axe(DamageType dType, float attackPower, string name) : base(dType, attackPower, name)
    {
        TypeOfWeapon = WeaponType.Axe;
    }

    public void BreakRock()
    {

    }

    //Whirlwind
    public override void SpecialAttack()
    {
        //ToArray because we remove an enemy if he dies
        foreach (var enemy in GameManager.Instance.CharManagerInstance.EnemyList.ToArray())
        {
            if (GameManager.Instance.CharManagerInstance.VectorFromSelectedChar(enemy.VEnemy).magnitude <= 1.5f)

            {
                enemy.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage() * 0.75f);
            }
        }
    }
}
