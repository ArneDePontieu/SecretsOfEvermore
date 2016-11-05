using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public static GameManager Instance = null;

    //Managers
    public UIManager UIManagerInstance;
    public CharacterManager CharManagerInstance;
    public LevelManager LevelManagerInstance;

    public Inventory CharacterInventory;


    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    [SerializeField]
    private GameObject VisualItem;
    [SerializeField]
    private GameObject VisualEnemy;

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //First thing that gets executed after object is created
    void Start()
    {

    }

    //What happens when the game updates
    void Update()
    {
        CharManagerInstance.Refresh();
        UIManagerInstance.Refresh();
    }

    //Spawn an item
    public void SpawnItem(LevelManager.ItemSpawnInfo info)
    {
        //Create the item
        GameObject item = (GameObject)Instantiate(VisualItem);
        //Add the item info to it
        item.GetComponent<VisualItem>().Info = info.item;
        //Set the world position of the item
        item.transform.position = new Vector3(info.xPos, info.yPos, 0);
    }

    //Spawn an enemy
    public void SpawnEnemy(LevelManager.EnemySpawnInfo enemyInfo)
    {
        //Create the enemy
        GameObject enemy = (GameObject)Instantiate(VisualEnemy);
        //Add the enemy info to it
        enemy.GetComponent<VisualEnemy>().Info = enemyInfo.enemy;
        enemyInfo.enemy.VEnemy = enemy.GetComponent<VisualEnemy>();
        //Set the world position of the enemy
        enemy.transform.position = new Vector3(enemyInfo.xPos, enemyInfo.yPos, 0.0f);
    }

    //Calculate damage numbers
    public float CalculateDamage(float defence, float damage)
    {
        if (damage <= defence)
        {
            return damage / 2.0f;
        }
        else
        {
            return damage / 2.0f + (damage / 2.0f) * (defence/damage);
        }
    }

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //Create the manager instances
        Instance = this;
        UIManagerInstance = new UIManager();
        CharManagerInstance = new CharacterManager();
        LevelManagerInstance = new LevelManager();

        //Create the inventory
        CharacterInventory = new Inventory();

        //Initialize the character stats
        CharManagerInstance.InitializeCharacterStats();

        //Initialize the inventory
        CharacterInventory.Initialize();

        //Load the first level
        LevelManagerInstance.LoadLevel(1);
    }

    //Things to call when the level is loaded
    void OnLevelWasLoaded(int level)
    {
        //Initialize the managers when a level gets loaded
        UIManagerInstance.Initialize();
        CharManagerInstance.Initialize();

        //Spawn items
        foreach (var it in LevelManagerInstance.GetItemSpawnList(level))
        {
            SpawnItem(it);
        }

        //Spawn Enemies
        foreach (var it in LevelManagerInstance.GetEnemySpawnList(level))
        {
            SpawnEnemy(it);
            CharManagerInstance.EnemyList.Add(it.enemy);
        }
    }


}
