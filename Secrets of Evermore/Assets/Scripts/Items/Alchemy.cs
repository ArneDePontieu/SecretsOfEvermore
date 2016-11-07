using UnityEngine;
using System.Collections;

public class Alchemy : Item
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public bool IsHidden = true;

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Constructor
    public Alchemy(string name) : base(name)
    {
        TypeItem = ItemType.Alchemy;
    }
}
