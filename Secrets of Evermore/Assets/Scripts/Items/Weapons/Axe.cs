using UnityEngine;
using System.Collections;

public class Axe : Weapon {

    public Axe(DamageType dType, float attackPower, string name) :base(dType,attackPower,name)
    {
        TypeOfWeapon = WeaponType.Axe;
    }

    public void BreakRock()
    {

    }

    //Whirlwind
    public override void SpecialAttack()
    {
        foreach (var enemy in GameManager.Instance.CharManagerInstance.EnemyList)
        {
            if (GameManager.Instance.CharManagerInstance.DistanceToSelectedChar(enemy.VEnemy)<=1.0f)

            {
                enemy.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage()*0.75f);
            }
        }
    }

    //Basic Attack
    public override void BasicAttack()
    {
        SpecialAttack();
    }

}
