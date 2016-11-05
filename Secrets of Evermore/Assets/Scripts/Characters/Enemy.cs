using UnityEngine;
using System.Collections;

public class Enemy : Character
{

    public VisualEnemy VEnemy;

    public Enemy(string name, float maxHealth, float attackLevel, float defenceLevel, float moveSpeed)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackLevel = attackLevel;
        DefenceLevel = defenceLevel;
        MovementSpeed = moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0.0f)
        {
            VEnemy.Suicide();
            GameManager.Instance.CharManagerInstance.RemoveEnemy(this);
        }
    }
}
