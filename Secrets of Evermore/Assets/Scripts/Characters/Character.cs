using UnityEngine;
using System.Collections;

public abstract class Character
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public string Name { get; set; }
    public float Health { get; set; }
    public int Level { get; set; }
    public float AttackLevel { get; set; }
    public float DefenceLevel { get; set; }
    public float MovementSpeed { get; set; }
    public float MaxHealth { get; set; }
    public float AttackDelay { get; set; }
    public float AttackCounter { get; set; }
    
    //----------------------
    //PUBLIC METHODS
    //----------------------

    //public abstract void Update();
    //public abstract void Move();

}

//+ contains all info related to chars (name, hp, weap, stats, level, att, def,...)
