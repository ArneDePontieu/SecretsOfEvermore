using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishLevelPanel : EvermorePanel {

    //PRIVATE VARIABLES
    [SerializeField]
    private GameObject panelTextObject;

    //PUBLIC VARIABLES

    //PUBLIC METHODS

    public override void Initialize()
    {


    }

    public override void Refresh()
    {

    }

    public void SetText(string txt)
    {
        panelTextObject.GetComponent<Text>().text = txt;
    }


    public void RestartLevel()
    {
        GameManager.Instance.LevelManagerInstance.LoadLevel(1);
    }

    public void QuitGame()
    {

    }

}
