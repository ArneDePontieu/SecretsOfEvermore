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
    public int AttackLevel { get; set; }
    public int DefenseLevel { get; set; }
    public float MovementSpeed { get; set; }
    public float MaxHealth { get; set; }
    
    //----------------------
    //PUBLIC METHODS
    //----------------------

    //public abstract void Update();
    //public abstract void Move();

}

//+ contains all info related to chars (name, hp, weap, stats, level, att, def,...)
