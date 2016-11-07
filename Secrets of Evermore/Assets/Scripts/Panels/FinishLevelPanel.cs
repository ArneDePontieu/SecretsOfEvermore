using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevelPanel : EvermorePanel {

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    [SerializeField]
    private GameObject panelTextObject;

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public override void Initialize()
    {}

    public override void Refresh()
    {}

    //Set the text when you finish a level
    public void SetText(string txt)
    {
        panelTextObject.GetComponent<Text>().text = txt;
    }

    //Restart the level
    public void RestartLevel()
    {
        GameManager.Instance.LevelManagerInstance.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    //Quit the application
    public void QuitGame()
    {
        Application.Quit();
    }

}
