using UnityEngine;
using System.Collections;

public class FinishLevelPanel : EvermorePanel {



    //PUBLIC METHODS

    public override void Initialize()

    {


    }

    public override void Refresh()
    {

    }

    public void RestartLevel()
    {
        GameManager.Instance.LevelManagerInstance.LoadLevel(1);
    }

    public void QuitGame()
    {

    }

}
