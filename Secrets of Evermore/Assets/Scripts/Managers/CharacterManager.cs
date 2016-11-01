using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{
    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //List of controllable characters
    private List<Avatar> _characterList = new List<Avatar>();
    //List of enemies
    private List<Enemy> _enemyList = new List<Enemy>();
    //the ID of the selected character
    private int _selectedCharacterID = 0;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public CharacterManager()
    {
        
    }

    public void Update()
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
        if(charID != _selectedCharacterID)
        {
            //Check if the ID is bigger than the size, if so reset
            if(charID>=_characterList.Count)
            {
                charID = 0;
            }
            //Remove the IsSelected from the previous selected char and set it for the new
            _characterList[_selectedCharacterID].IsSelected = false;
            _selectedCharacterID = charID;
            _characterList[_selectedCharacterID].IsSelected = true;
        }
    }

    public void Initialize()
    {
        InitializeLevel();
    }

    public void InitializeLevel()
    {
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
        _characterList.Add(human);
        _characterList.Add(dog);

        //Find all the avatar tagged mobs and assign their info to them
        var playerChars = GameObject.FindGameObjectsWithTag("Avatar");
        foreach (var aObject in playerChars)
        {
            for(int i = 0; i<_characterList.Count;i++)
            {
                if (aObject.gameObject.name == _characterList[i].Name)
                {
                    aObject.GetComponent<VisualCharacter>().info = _characterList[i];
                    if(_characterList[i].Name == "Boy")
                    {
                        _selectedCharacterID = i;
                    }
                    break;
                }
            }
        }
    }
}
