using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class VisualEnemy : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    [SerializeField]
    private GameObject HealthBar;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Enemy Info;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Update()
    {
        //Display the health bar
        HealthBar.GetComponent<Image>().fillAmount = Info.Health / Info.MaxHealth;

        //Attack counter
        Info.AttackCounter += Time.deltaTime;
        //Move
        Move();
    }

    //MOVE to the Enemy
    private void Move()
    {
        //List of potential targets
        List<RaycastHit2D> targetList = new List<RaycastHit2D>();

        //Loop through the avatar list and check if one of them is visible
        foreach (var avatar in GameManager.Instance.CharManagerInstance.CharacterList)
        {
            //Combine layermasks
            var layerMask = (1 << LayerMask.NameToLayer("CharacterLayer")) | (1 << LayerMask.NameToLayer("LevelLayer"));

            RaycastHit2D hit = Physics2D.Raycast(transform.position, avatar.VCharacter.transform.position - transform.position,
                Info.AggroRange,
                layerMask);

            //Only do something if the hit collider is not 0
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Avatar")
                {
                    targetList.Add(hit);
                }
            }
        }

        //distance
        float distance = Mathf.Infinity;
        Avatar mainTarget = null;

        //Check the closest taret
        foreach (var target in targetList)
        {
            if (target.distance <= distance && (target.collider.gameObject.GetComponent<VisualCharacter>().Info.Name != "Dog" || GameManager.Instance.CharManagerInstance.CanSwap))
            {
                distance = target.distance;
                mainTarget = target.collider.gameObject.GetComponent<VisualCharacter>().Info;
            }
        }

        //If it's not null, do something
        if (mainTarget != null)
        {
            if (distance <= 1.0f)
            {
                Attack(mainTarget);
            }
            else
            {
                transform.position = transform.position + (mainTarget.VCharacter.transform.position - transform.position).normalized * Time.deltaTime;
            }
        }
    }

    private void Attack(Avatar avatar)
    {
        //Attack
        if (Info.AttackCounter >= Info.AttackDelay)
        {
            avatar.TakeDamage(Info.AttackLevel);
            Info.AttackCounter = 0;
        }
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
