using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;

public class CharacterPanel : EvermorePanel
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private float _xStartPos = 0.0f;
    private float _yStartPos = 200.0f;
    //the relative positions will change for every line you add
    private float _xRelPos = 0.0f;
    private float _yRelPos = 0.0f;
    //Height of a line
    private float _lineHeight = 30.0f;

    public struct StatValue
    {
        public string ItemName;
        public string TypeName;
        public float Value;
        public GameObject DisplayObject;
    }

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public GameObject PanelText;
    public List<StatValue> CharacterStats = new List<StatValue>();

    //----------------------
    //PRIVATE METHODS
    //----------------------

    private void AddLine(float x, float y, string text, bool title)
    {
        //Add the text to the panel
        GameObject pText = (GameObject)Instantiate(PanelText);
        pText.transform.SetParent(this.gameObject.transform);
        pText.transform.localPosition = new Vector3(x, y, 0);

        //Change the relative Y position so we go to the next line
        _yRelPos -= _lineHeight;

        //If it's not a title we add it to the list so we can access it later
        if (!title)
        {
            //Create a new statvalue variable we can add to the list
            StatValue display = new StatValue();
            display.ItemName = "";
            display.TypeName = text;
            display.DisplayObject = pText;
            display.Value = 0.0f;

            CharacterStats.Add(display);
        }
        else
        {
            //This text is not in the list so won't be updated, because of this we have to update it here
            pText.GetComponent<Text>().text = text;
        }
    }

    private StatValue GetStatValue(string typeName)
    {
        //The index where the statvalue is we want to return
        var index = -1;

        //Check where it is
        for (int i = 0; i < CharacterStats.Count; i++)
        {
            if (CharacterStats[i].TypeName == typeName)
            {
                index = i;
                break;
            }
        }

        if (index >= 0)
        {
            return CharacterStats[index];
        }
        else
        {
            //return something in case we don't find what we need
            return new StatValue();
        }

    }

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public override void Initialize()
    {
        //List the damage first
        AddLine(_xStartPos + _xRelPos, _yStartPos + _yRelPos, "ATTACK POWER", true);
        AddLine(_xStartPos + _xRelPos, _yStartPos + _yRelPos, "Weapon", false);

        //List the defence second
        _yRelPos -= _lineHeight;
        AddLine(_xStartPos + _xRelPos, _yStartPos + _yRelPos, "DEFENCE", true);
        for (int i = 0; i < Enum.GetNames(typeof(Armor.ArmorType)).Length; i++)
        {
            AddLine(_xStartPos + _xRelPos, _yStartPos + _yRelPos, Enum.GetNames(typeof(Armor.ArmorType))[i].ToString(), false);
        }
    }

    public override void Refresh()
    {
        //Check the inventory for items and update the info
        foreach (var item in GameManager.Instance.CharacterInventory.ItemList)
        {
            //Get the corresponding text cell for the item
            if (item.TypeItem == Item.ItemType.Armor || item.TypeItem == Item.ItemType.Weapon)
            {
                //Variable we will be assigning to edit the text
                StatValue statValue = new StatValue();
                string typeName = "";

                //Do something depending on what the item is
                switch (item.TypeItem)
                {
                    //What to do if it's a weapon
                    case Item.ItemType.Weapon:
                        var weapon = item as Weapon;
                        typeName = "Weapon";

                        statValue.ItemName = weapon.Name;
                        statValue.Value = weapon.AttackPower;
                        break;
                    //What to do if it's armor
                    case Item.ItemType.Armor:
                        var armor = item as Armor;
                        typeName = armor.TypeArmor.ToString();

                        statValue.ItemName = armor.Name;
                        statValue.Value = armor.DefenceValue;
                        break;
                }

                //Now change the info in the list
                for (int i = 0; i < CharacterStats.Count; i++)
                {
                    if (CharacterStats[i].TypeName == typeName)
                    {
                        //Copy the typename and object to the new StatValue, because these don't change
                        statValue.TypeName = CharacterStats[i].TypeName;
                        statValue.DisplayObject = CharacterStats[i].DisplayObject;

                        CharacterStats[i] = statValue;
                        break;
                    }
                }

            }
        }

        //Display the text for the values
        foreach(var statValue in CharacterStats)
        {
            //Create a stringstream to display the values
            StringWriter stream = new StringWriter();
            stream.Write(statValue.TypeName);
            stream.Write(": ");
            stream.Write(statValue.ItemName);
            stream.Write(" - ");
            stream.Write(statValue.Value);

            //Update the text
            statValue.DisplayObject.GetComponent<Text>().text = stream.ToString();
        }
    }

}
