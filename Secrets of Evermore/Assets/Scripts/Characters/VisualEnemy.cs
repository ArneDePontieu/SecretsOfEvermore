using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualEnemy : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    public GameObject HealthBar;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Enemy Info;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Update()
    {
        HealthBar.GetComponent<Image>().fillAmount = Info.Health / Info.MaxHealth;
    }

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Kill the enemy
    public void Suicide()
    {
        Destroy(this.gameObject);
    }
}
