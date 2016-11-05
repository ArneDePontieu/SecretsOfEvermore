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

    public Weapon(DamageType dType, float attackPower, string name) : base(name)
    {
        TypeOfDamage = dType;
        AttackPower = attackPower;
        TypeItem = ItemType.Weapon;
    }

    //All the weapons will get the same basic attack
    public void BasicAttack()
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
            if (hit.collider.gameObject.tag == "Enemy" && hit.distance <= 1.0f)
            {
                hit.collider.gameObject.GetComponent<VisualEnemy>().Info.TakeDamage(GameManager.Instance.CharManagerInstance.GetSelectedCharacterDamage());
            }
        }
    }

    //Every weapon has a different special attack
    public abstract void SpecialAttack();
}
