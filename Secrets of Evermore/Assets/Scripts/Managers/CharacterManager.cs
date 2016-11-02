﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{
    //----------------------
    //PRIVATE VARIABLES
    //----------------------
    //List of enemies
    private List<Enemy> _enemyList = new List<Enemy>();
    //the ID of the selected character
    private int _selectedCharacterID = 0;
    //Camera variable
    private GameObject _camera;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    //List of controllable characters
    public List<Avatar> CharacterList = new List<Avatar>();

    //----------------------
    //PRIVATE METHODS
    //----------------------

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

    }

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

    public void Initialize()
    {
        InitializeLevel();
    }

    public void InitializeLevel()
    {
        //Put the camera in a variable
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        _camera = camera;

        //Create the human
        Avatar human = new Avatar();
        human.Name = "Boy";
        human.MovementSpeed = 5.0f;
        human.Level = 1;
        human.AttackLevel = 1;
        human.DefenseLevel = 1;
        human.IsSelected = true;
        human.MaxHealth = 100.0f;
        human.Health = human.MaxHealth;
        

        //Create the dog
        Avatar dog = new Avatar();
        dog.Name = "Dog";
        dog.MovementSpeed = 5.0f;
        dog.Level = 1;
        dog.AttackLevel = 1;
        dog.DefenseLevel = 1;
        dog.IsSelected = false;
        dog.MaxHealth = 100.0f;
        dog.Health = dog.MaxHealth;

        //Add them to the list
        CharacterList.Add(human);
        CharacterList.Add(dog);

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
    }
}
