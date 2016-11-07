using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private List<ItemSpawnInfo> ItemSpawnList = new List<ItemSpawnInfo>();
    private List<EnemySpawnInfo> EnemySpawnList = new List<EnemySpawnInfo>();

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    //Information about an item spawn
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

    //Information about an enemy spawn
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

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //When you finish a level
    public void FinishLevel(string txt)
    {
        GameManager.Instance.UIManagerInstance.FinLevelPanel.SetText(txt);
        GameManager.Instance.UIManagerInstance.FinLevelPanel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    //Load a level
    public void LoadLevel(int level)
    {
        if (level <= SceneManager.sceneCount)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(level);
        }
    }

    //Get the list of items to spawn
    public List<ItemSpawnInfo> GetItemSpawnList()
    {
        return ItemSpawnList;
    }

    //Initialize the list of items to spawn
    public List<ItemSpawnInfo> InitializeItemSpawnList(int level)
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
                ItemSpawnList.Add(new ItemSpawnInfo(new Alchemy("Salt"), -0.5f, 12.84f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Alchemy("Sugar"), -16.34f, -4.3f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Alchemy("Banana"), -10.0f, -17.84f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Alchemy("Rock"), -32.31f, 13.16f));
                ItemSpawnList.Add(new ItemSpawnInfo(new Alchemy("Salt"), 54.21f, 7.69f));
                break;
        }

        //Return the list
        return ItemSpawnList;
    }

    //Initialize the list of enemies that have to get spawned
    public List<EnemySpawnInfo> InitializeEnemySpawnList(int level)
    {
        //Clear the spawnlist before adding things
        EnemySpawnList.Clear();

        switch (level)
        {
            case 1:
                //Enemies
                Enemy enemy = new Enemy("Goblin", 20.0f, 5.0f, 5.0f, 1.0f, 7.0f);
                enemy.AttackDelay = 0.5f;
                enemy.ItemDrop = new Sword(Weapon.DamageType.Physical, 50.0f, "Sword of the gods");
                EnemySpawnList.Add(new EnemySpawnInfo(enemy, 8.0f, 7.0f));

                enemy = new Enemy("Giblin", 20.0f, 5.0f, 5.0f, 1.0f, 7.0f);
                enemy.AttackDelay = 0.5f;
                enemy.ItemDrop = new Armor(5.0f, "Wicked helm", Armor.ArmorType.Head);
                EnemySpawnList.Add(new EnemySpawnInfo(enemy, 8.0f, 5.0f));

                enemy = new Enemy("Dungeon Boss", 200.0f, 20.0f, 10.0f, 1.0f, 7.0f);
                enemy.AttackDelay = 1.0f;
                enemy.ItemDrop = new Quest("Minitaur Head");
                EnemySpawnList.Add(new EnemySpawnInfo(enemy, 46.0f, -13.3f));

                break;
        }

        //Return the list
        return EnemySpawnList;
    }

    //Remove an item from the list of items that are spawned in the levels
    public void RemoveItemFromLevel(Item item)
    {
        foreach (var itemSpawnInfo in ItemSpawnList.ToArray())
        {
            if (itemSpawnInfo.item == item)
            {
                ItemSpawnList.Remove(itemSpawnInfo);
                return;
            }
        }
    }
}
