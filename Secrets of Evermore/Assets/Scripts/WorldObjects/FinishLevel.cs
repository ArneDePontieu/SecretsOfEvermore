using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

    //PRIVATE METHODS    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.LevelManagerInstance.FinishLevel("Congratulations, you got to the end!");
    }
}
