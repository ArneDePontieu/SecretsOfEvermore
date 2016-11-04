using UnityEngine;
using System.Collections;

public class Quest : Item
{

    public Quest(string name):base(name)
    {
        TypeItem = ItemType.Quest;
    }

}
