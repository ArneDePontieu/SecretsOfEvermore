using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager
{

    //private variables

    //public variables
    public List<SpawnInfo> spawnList = new List<SpawnInfo>();

    public struct SpawnInfo
    {
        public Item item;
        public float xPos;
        public float yPos;

        public SpawnInfo(Item it, float x, float y)
        {
            item = it;
            xPos = x;
            yPos = y;
        }
    }

    //Public Methods
    public void Initialize()
    {

    }

    public void Refresh()
    {

    }

    public void LoadLevel(int level)
    {
        if (level <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(level);
        }
    }

    public List<SpawnInfo> GetSpawnList(int level)
    {
        //Clear the spawnlist before adding things
        spawnList.Clear();

        switch (level)
        {
            case 1:
                spawnList.Add(new SpawnInfo(new Quest("Golden Key"), 9.7f, -7.5f));
                spawnList.Add(new SpawnInfo(new Armor(5.0f, "Magical Pants", Armor.ArmorType.Pants), -9.5f, 4.2f));
                break;
        }

        //Return the list
        return spawnList;
    }
}
