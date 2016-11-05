using UnityEngine;
using System.Collections;

public class Avatar : Character
{

    public bool IsSelected { get; set; }
    public VisualCharacter VCharacter { get; set; }

    public float BonusWeaponDamage { get; set; }
    public float BonusArmorDefence { get; set; }

    public Avatar()
    {
        BonusArmorDefence = 0.0f;
        BonusWeaponDamage = 0.0f;
    }

    //Take damage
    public void TakeDamage(float damage)
    {
        Health -= GameManager.Instance.CalculateDamage(DefenceLevel, damage);
        //If Boy dies game over, else not game over but you can't swap anymore to the dog
        if (Name == "Boy")
        {
            if (Health <= 0)
            {
                Health = 0;
                GameManager.Instance.LevelManagerInstance.FinishLevel("You died! Game Over.");
            }
        }
        else
        {
            if (Health <= 0)
            {
                GameManager.Instance.CharManagerInstance.CanSwap = false;
                Health = 0;
                //Don't forceswap if the dog dies but your character doesn't
                if (GameManager.Instance.CharManagerInstance.GetSelectedCharacter().Name == "Dog")
                {
                    GameManager.Instance.CharManagerInstance.ForceSwap = true;
                }

            }
        }


    }

}
