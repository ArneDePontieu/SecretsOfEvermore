using UnityEngine;
using System.Collections;

public class Quest : Item
{

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Constructor
    public Quest(string name) : base(name)
    {
        TypeItem = ItemType.Quest;
    }
}
