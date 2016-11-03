using UnityEngine;
using System.Collections;

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
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _canPickUp = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _canPickUp = false;
    }
}
