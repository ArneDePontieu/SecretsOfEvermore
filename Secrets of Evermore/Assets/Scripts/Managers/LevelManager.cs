﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager
{

    //private variables

    //public variables
    public List<ItemSpawnInfo> ItemSpawnList = new List<ItemSpawnInfo>();
    public List<EnemySpawnInfo> EnemySpawnList = new List<EnemySpawnInfo>();

    public struct ItemSpawnInfo
    {
        public Item item;
        public float xPos;
        public float yPos;

        public ItemSpawnInfo(Item it, float x, float y)
        {
            item = it;
            xPos = x;
            yPos = y;
        }
    }

    public struct EnemySpawnInfo
    {
        public Enemy enemy;
        public float xPos;
        public float yPos;

        public EnemySpawnInfo(Enemy en, float x, float y)
        {
            enemy = en;
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

    public void FinishLevel()
    {
        GameManager.Instance.UIManagerInstance.FinLevelPanel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void LoadLevel(int level)
    {
        if (level <= SceneManager.sceneCount)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(level);
        }
    }

    public List<ItemSpawnInfo> GetItemSpawnList(int level)
    {
        //Clear the spawnlist before adding things
        ItemSpawnList.Clear();

        switch (level)
        {
            case 1:
                //Items
                ItemSpawnList.Add(new ItemSpawnInfo(new Quest("Golden Key"), 9.7f, -7.5f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Quest("Ruby Statue"), -17.0f, 13.0f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Quest("Emerald Statue"), 25.5f, 13.0f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Quest("Diamond Statue"), 46.0f, 8.0f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Quest("Golden Statue"), 39.7f, -12.4f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Armor(5.0f, "Magical Pants", Armor.ArmorType.Pants), -9.5f, 4.2f));

                break;
        }

        //Return the list
        return ItemSpawnList;
    }

    //Get the list of enemies that have to get spawned
    public List<EnemySpawnInfo> GetEnemySpawnList(int level)
    {
        //Clear the spawnlist before adding things
        EnemySpawnList.Clear();

        switch (level)
        {
            case 1:
                //Enemies
                EnemySpawnList.Add(new EnemySpawnInfo(new Enemy("Goblin", 20.0f, 5.0f, 5.0f, 1.0f), 8.0f, 7.0f));
                break;
        }

        //Return the list
        return EnemySpawnList;
    }



}
