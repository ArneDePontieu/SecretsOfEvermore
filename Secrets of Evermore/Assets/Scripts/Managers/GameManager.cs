using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public UIManager UIManagerInstance;
    public CharacterManager CharManagerInstance;

    //Get the instance of the game manager (only one game manager)
    public static GameManager Instance
    {
        get { return _instance; }
    }

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //Instance of the game manager
    private static GameManager _instance = new GameManager();

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

    }
    //----------------------
    //PRIVATE METHODS
    //----------------------

    //Private constructor
    private GameManager()
    {
        UIManagerInstance = new UIManager();
        CharManagerInstance = new CharacterManager();
    }








}
