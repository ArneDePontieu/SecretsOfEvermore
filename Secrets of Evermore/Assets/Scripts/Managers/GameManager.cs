using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public static GameManager Instance = null;
    public UIManager UIManagerInstance;
    public CharacterManager CharManagerInstance;
    public Inventory CharacterInventory;
 
    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //First thing that gets executed after object is created
    void Start()
    {
        UIManagerInstance.Initialize();
        CharacterInventory.Initialize();
    }

    //What happens when the game updates
    void Update()
    {
        CharManagerInstance.Refresh();
        UIManagerInstance.Refresh();
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

        //Create the inventory
        CharacterInventory = new Inventory();

        //Initialize the character manager
        CharManagerInstance.Initialize();
    }
}
