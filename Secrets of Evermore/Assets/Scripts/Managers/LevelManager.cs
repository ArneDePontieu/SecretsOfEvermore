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
        public int xPos;
        public int yPos;

        public SpawnInfo(Item it, int x, int y)
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
        if (level<=SceneManager.sceneCount)
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
                spawnList.Add(new SpawnInfo(new Axe(Weapon.WeaponType.TwoHander, Weapon.DamageType.Physical, 20, "Axe of Doom"), 3, 3));
                spawnList.Add(new SpawnInfo(new Armor(50,"Mithril Helmet",Armor.ArmorType.Head), -3, 5));
                break;
        }

        //Return the list
        return spawnList;
    }
}
