using UnityEngine;
using System.Collections;
using System.IO;

public class VisualItem : MonoBehaviour {

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private bool _canPickUp = false;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Item Info;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public void Update()
    {
        if (Info != null)
        {
            //Do stuff if there is itemInfo
            if (Input.GetKeyDown(KeyCode.F) && _canPickUp == true)
            {
                //Add the item to the inventory, return true if succeeds
                bool isPickedUp = GameManager.Instance.CharacterInventory.AddItem(Info);
                //If it succeeds, remove the visual item
                if(isPickedUp)
                {
                    Destroy(this.gameObject);
                    GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(false);
                }
                else
                {
                    GameManager.Instance.UIManagerInstance.NotificationText.text = "You can't pick up this item because you already have a better item in your inventory.";
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Avatar") {
            _canPickUp = true;

            //enable the text
            GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(true);
            //set the notification
            StringWriter writer = new StringWriter();
            writer.Write("Press \'F\' to pick up ");
            writer.Write(Info.Name);
            GameManager.Instance.UIManagerInstance.NotificationText.text = writer.ToString();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Avatar")
        {
            _canPickUp = false;

            //disable the text
            GameManager.Instance.UIManagerInstance.NotificationText.gameObject.SetActive(false);
        }
    }
}
