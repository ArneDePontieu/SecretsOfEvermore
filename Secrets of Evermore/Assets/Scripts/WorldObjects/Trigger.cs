using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{

    //PUBLIC VARIABLES
    public bool TriggerOnce;
    public List<GameObject> TriggerLinks;

    public bool ItemRequired = false;
    public string ItemName;

    //PRIVATE METHODS

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var link in TriggerLinks)
        {
            //Only activate if you have the required item, unless you don't need an item
            if ((ItemRequired && GameManager.Instance.CharacterInventory.CheckForItem(ItemName)) || !ItemRequired)
            {
                link.GetComponent<MovingObject>().AddActivatedTrigger(other.gameObject.GetInstanceID());

                //remove the item from your inventory
                if(ItemRequired)
                {
                    GameManager.Instance.CharacterInventory.RemoveItem(ItemName);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!TriggerOnce && !ItemRequired)
        {
            foreach (var link in TriggerLinks)
            {
                link.GetComponent<MovingObject>().RemoveActivatedTrigger(other.gameObject.GetInstanceID());
            }

        }
    }
}
