using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //Boy UI
    private Image HealthBarBoy;
    private Text HealthMaxBoy;
    private Text HealthCurrBoy;
    //Dog UI
    private Image HealthBarDog;
    private Text HealthMaxDog;
    private Text HealthCurrDog;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Start()
    {
        foreach (Transform child in transform)
        {
            //Boy
            if (child.gameObject.name == "HealthBarBoy")
            {
                HealthBarBoy = child.gameObject.GetComponent<Image>();
            }
            if (child.gameObject.name == "HealthMaxBoy")
            {
                HealthMaxBoy = child.gameObject.GetComponent<Text>();
            }
            if (child.gameObject.name == "HealthCurrBoy")
            {
                HealthCurrBoy = child.gameObject.GetComponent<Text>();
            }
            //Dog
            if (child.gameObject.name == "HealthBarDog")
            {
                HealthBarDog = child.gameObject.GetComponent<Image>();
            }
            if (child.gameObject.name == "HealthMaxDog")
            {
                HealthMaxDog = child.gameObject.GetComponent<Text>();
            }
            if (child.gameObject.name == "HealthCurrDog")
            {
                HealthCurrDog = child.gameObject.GetComponent<Text>();
            }
        }
    }

    void Update()
    {
        foreach (var avatar in GameManager.Instance.CharManagerInstance.CharacterList)
        {
            if (avatar.Name == "Boy")
            {
                HealthBarBoy.fillAmount = avatar.Health / avatar.MaxHealth;
                HealthMaxBoy.text = avatar.MaxHealth.ToString();
                HealthCurrBoy.text = avatar.Health.ToString();
            }
            if (avatar.Name == "Dog")
            {
                HealthBarDog.fillAmount = avatar.Health / avatar.MaxHealth;
                HealthMaxDog.text = avatar.MaxHealth.ToString();
                HealthCurrDog.text = avatar.Health.ToString();
            }
        }
        ////Health bar boy
        //HealthBarBoy.GetComponent<Image>().fillAmount = 
    }
}
