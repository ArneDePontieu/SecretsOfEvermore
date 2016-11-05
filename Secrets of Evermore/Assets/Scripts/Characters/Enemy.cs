using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character
{

    public VisualEnemy VEnemy;
    public Item ItemDrop;
    public float AggroRange;

    public Enemy(string name, float maxHealth, float attackLevel, float defenceLevel, float moveSpeed, float aggroRange)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        AttackLevel = attackLevel;
        DefenceLevel = defenceLevel;
        MovementSpeed = moveSpeed;
        AggroRange = aggroRange;
    }

    //PUBLIC METHODS
    public void TakeDamage(float damage)
    {
        GameManager.Instance.CalculateDamage(DefenceLevel, damage);

        Health -= GameManager.Instance.CalculateDamage(DefenceLevel, damage);
        if (Health <= 0.0f)
        {
            DropItem();
            VEnemy.Suicide();
            GameManager.Instance.CharManagerInstance.RemoveEnemy(this);
        }
    }

    //PRIVATE METHOD
    private void DropItem()
    {
        if (ItemDrop != null)
        {
            //Spawn the item on the loot table
            LevelManager.ItemSpawnInfo spawnInfo = new LevelManager.ItemSpawnInfo(ItemDrop, VEnemy.transform.position.x, VEnemy.transform.position.y);
            GameManager.Instance.SpawnItem(spawnInfo);
        }
    }
}
