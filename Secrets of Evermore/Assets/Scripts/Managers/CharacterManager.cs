using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{
    //----------------------
    //PRIVATE VARIABLES
    //----------------------
    //the ID of the selected character
    private int _selectedCharacterID = 0;
    //Camera variable
    private GameObject _camera;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    //List of controllable characters
    public List<Avatar> CharacterList = new List<Avatar>();
    //List of enemies
    public List<Enemy> EnemyList = new List<Enemy>();

    //----------------------
    //PRIVATE METHODS
    //----------------------

    private void SelectCharacter(int charID)
    {
        //Check if the ID is different than the previous
        if (charID != _selectedCharacterID)
        {
            //Check if the ID is bigger than the size, if so reset
            if (charID >= CharacterList.Count)
            {
                charID = 0;
            }

            //Remove the IsSelected from the previous selected char and set it for the new
            CharacterList[_selectedCharacterID].IsSelected = false;
            _selectedCharacterID = charID;
            CharacterList[_selectedCharacterID].IsSelected = true;

            //Change the camera parent
            _camera.transform.parent = CharacterList[_selectedCharacterID].VCharacter.transform;

            //Set the camera position on the location of the character
            var camPos = _camera.transform.position;
            camPos = CharacterList[_selectedCharacterID].VCharacter.transform.position;
            camPos.z = -10;
            _camera.transform.position = camPos;
        }
    }

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public CharacterManager()
    {

    }

    public void Refresh()
    {
        //Swap character when pressing spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCharacter(_selectedCharacterID + 1);
        }


        //Give the info of the selected character to the other characters
        for (int i = 0; i < CharacterList.Count; i++)
        {
            CharacterList[i].VCharacter.SelectedChar = CharacterList[_selectedCharacterID].VCharacter;
        }

    }

    public void Initialize()
    {
        InitializeCharactersLevel();
    }

    public void InitializeCharacterStats()
    {
        //Create the human
        Avatar human = new Avatar();
        human.Name = "Boy";
        human.MovementSpeed = 5.0f;
        human.Level = 1;
        human.AttackLevel = 1.0f;
        human.DefenceLevel = 1;
        human.IsSelected = true;
        human.MaxHealth = 100.0f;
        human.Health = human.MaxHealth;
        human.AttackDelay = 0.5f;


        //Create the dog
        Avatar dog = new Avatar();
        dog.Name = "Dog";
        dog.MovementSpeed = 5.0f;
        dog.Level = 1;
        dog.AttackLevel = 1;
        dog.DefenceLevel = 1;
        dog.IsSelected = false;
        dog.MaxHealth = 100.0f;
        dog.Health = dog.MaxHealth;
        dog.AttackDelay = 0.5f;

        //Add them to the list
        CharacterList.Add(human);
        CharacterList.Add(dog);       

        //Update the character stats on launch
        UpdateCharacterStats();
    }

    public void InitializeCharactersLevel()
    {
        //Put the camera in a variable
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        _camera = camera;

        //Find all the avatar tagged mobs
        var playerChars = GameObject.FindGameObjectsWithTag("Avatar");
        //loop through every tagged mob
        foreach (var aObject in playerChars)
        {
            //loop through the avatar list to assign the info to them
            for (int i = 0; i < CharacterList.Count; i++)
            {
                //check if the name is equal --> correct object
                if (aObject.gameObject.name == CharacterList[i].Name)
                {
                    //Assign the info and the visual character so we can use this later for the camera
                    CharacterList[i].VCharacter = aObject.GetComponent<VisualCharacter>();
                    aObject.GetComponent<VisualCharacter>().Info = CharacterList[i];
                    //We start with the boy as character, so make the camera child and set the selected ID to the boy ID
                    if (CharacterList[i].Name == "Boy")
                    {
                        SelectCharacter(i);
                    }
                    break;
                }
            }
        }

        //Give the info of the selected character to the other characters
        for (int i = 0; i < CharacterList.Count; i++)
        {
            CharacterList[i].VCharacter.SelectedChar = CharacterList[_selectedCharacterID].VCharacter;
        }

    }

    public void UpdateCharacterStats()
    {
        //Reset the bonusarmor and damage
        foreach (var character in CharacterList)
        {
            character.BonusArmorDefence = 0;
            character.BonusWeaponDamage = 0;
        }

        float bonusArmor = 0.0f;
        float bonusDamage = 0.0f;

        //Check the inventory for items and update the stats
        foreach (var item in GameManager.Instance.CharacterInventory.ItemList)
        {
            if (item.TypeItem == Item.ItemType.Armor || item.TypeItem == Item.ItemType.Weapon)
            {
                //Do something depending on what the item is
                switch (item.TypeItem)
                {
                    //What to do if it's a weapon
                    case Item.ItemType.Weapon:
                        var weapon = item as Weapon;

                        //add bonus damage
                        if (weapon.TypeOfDamage != Weapon.DamageType.Magical)
                        {
                            bonusDamage += weapon.AttackPower;
                        }
                        break;
                    //What to do if it's armor
                    case Item.ItemType.Armor:
                        var armor = item as Armor;

                        //add bonus armor
                        bonusArmor += armor.DefenceValue;
                        break;
                }
            }
        }

        //Set the bonusarmor and damage to the new value
        foreach (var character in CharacterList)
        {
            character.BonusArmorDefence = bonusArmor;
            character.BonusWeaponDamage = bonusDamage;
        }
    }


    //Get the distance from the selected character to the enemy
    public Vector3 VectorFromSelectedChar(VisualEnemy enemy)
    {
        return (CharacterList[_selectedCharacterID].VCharacter.transform.position - enemy.transform.position);
    }

    //Get the damage from the selected character
    public float GetSelectedCharacterDamage()
    {
        return CharacterList[_selectedCharacterID].AttackLevel + CharacterList[_selectedCharacterID].BonusWeaponDamage;
    }

    public Avatar GetSelectedCharacter()
    {
        return CharacterList[_selectedCharacterID];
    }

    public void RemoveEnemy(Enemy enemy)
    {
        //Remove the enemy for the list
        //Do ToArray because we are removing an object in the list during the loop
        foreach (var e in EnemyList.ToArray())
        {
            if (e == enemy)
            {
                EnemyList.Remove(e);
            }
        }

    }
}
