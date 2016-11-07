using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public VisualEnemy VEnemy;
    public Item ItemDrop;
    public float AggroRange;

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Constructor
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

    //Take damage
    public void TakeDamage(float damage)
    {
        //Calculate the damage taken
        Health -= GameManager.Instance.CalculateDamage(DefenceLevel, damage);
        //If health drops below 0, die
        if (Health <= 0.0f)
        {
            //Die
            DropItem();
            VEnemy.Suicide();
            GameManager.Instance.CharManagerInstance.RemoveEnemy(this);
        }
    }

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //Drop an item when dead
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
