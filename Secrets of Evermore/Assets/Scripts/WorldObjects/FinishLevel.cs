using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

    //PUBLIC METHODS

    //PRIVATE METHODS
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.LevelManagerInstance.FinishLevel();
    }

}
