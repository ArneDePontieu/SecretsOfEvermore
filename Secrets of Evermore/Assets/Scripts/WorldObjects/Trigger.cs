using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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
            if (ItemRequired)
            {
                //Notification that you need an item to open this door
                GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(true);

                StringWriter writer = new StringWriter();
                writer.Write("You need \'");
                writer.Write(ItemName);
                writer.Write("\' to activate this trigger.");

                GameManager.Instance.UIManagerInstance.NotificationText.text = writer.ToString();
            }

            //Activate the trigger
            if ((GameManager.Instance.CharacterInventory.CheckForItem(ItemName) && ItemRequired) || !ItemRequired)
            {
                link.GetComponent<MovingObject>().AddActivatedTrigger(other.gameObject.GetInstanceID());

                //remove the item from your inventory
                if (ItemRequired)
                {
                    GameManager.Instance.CharacterInventory.RemoveItem(ItemName);
                    GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(false);
                }
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(false);
        if (!TriggerOnce && !ItemRequired)
        {
            foreach (var link in TriggerLinks)
            {
                link.GetComponent<MovingObject>().RemoveActivatedTrigger(other.gameObject.GetInstanceID());
            }

        }
    }
}
