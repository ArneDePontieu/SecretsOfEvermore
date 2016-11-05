using UnityEngine;
using System.Collections;

public class VisualEnemy : MonoBehaviour {

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Enemy Info;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public void Update()
    {

    }

    //Kill the enemy
    public void Suicide()
    {
        Destroy(this.gameObject);
    }

}
