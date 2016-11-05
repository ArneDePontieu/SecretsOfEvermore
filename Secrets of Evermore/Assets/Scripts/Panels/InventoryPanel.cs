using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class InventoryPanel : EvermorePanel
{
    //----------------------
    //PRIVATE METHODS
    //----------------------

    private float _xStartPos = -212;
    private float _yStartPos = 232;

    //----------------------
    //PUBLIC METHODS
    //----------------------
    //public List<Item> ItemList = new List<Item>();

    public GameObject InventorySlot;
    public List<GameObject> InvSlots = new List<GameObject>();

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public override void Initialize()
    {
        //Create the inventory slots
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject slot = (GameObject)Instantiate(InventorySlot);
                //slot.transform.parent = this.gameObject.transform;
                slot.transform.SetParent(this.gameObject.transform);
                InvSlots.Add(slot);

                //Positioning the slots
                Vector3 pos = Vector3.zero;
                pos.x = (x + 1) * 50 + _xStartPos - 10;
                pos.y = -((y + 1) * 50) + _yStartPos + 10;
                pos.z = 0;
                slot.transform.localPosition = pos;
            }
        }
    }

    public override void Refresh()
    {
        //Make all the slots empty visually
        foreach(var slot in InvSlots)
        {
            slot.GetComponent<Image>().color = Color.white;
        }

        //Give colors for the items
        for (int i = 0; i < GameManager.Instance.CharacterInventory.ItemList.Count; i++)
        {
            //Set a color depending on the type
            Color color = new Color();
            switch (GameManager.Instance.CharacterInventory.ItemList[i].TypeItem)
            {
                case Item.ItemType.Armor:
                    color = Color.red;
                    break;
                case Item.ItemType.Weapon:
                    color = Color.green;
                    break;
                case Item.ItemType.Quest:
                    color = Color.yellow;
                    break;
            }
            InvSlots[i].GetComponent<Image>().color = color;
        }
    }

}
