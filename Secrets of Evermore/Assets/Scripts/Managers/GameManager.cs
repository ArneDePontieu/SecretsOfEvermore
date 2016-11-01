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
 
    //----------------------
    //PRIVATE VARIABLES
    //----------------------

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        UIManagerInstance = new UIManager();
        CharManagerInstance = new CharacterManager();

        CharManagerInstance.Initialize();
    }
}
