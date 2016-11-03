using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private float followDistance = 3.0f;

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Avatar Info;
    public VisualCharacter SelectedChar;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public void Update()
    {
        if (Info != null)
        {
            Move();
        }
    }

    public void Move()
    {
        //Move with keys if IsSelected is true, otherwise move automatically    
        if (Info.IsSelected)
        {
            //Move with the arrow keys
            var move = new Vector3();
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            transform.position += move * Info.MovementSpeed * Time.deltaTime;
        }
        else
        {
            if(SelectedChar!=null)
            {
                //autofollow
                var distanceVector = SelectedChar.transform.position - transform.position;
                if (distanceVector.magnitude > followDistance)
                {
                    transform.position = transform.position + (distanceVector.normalized * Time.deltaTime * Info.MovementSpeed);
                }
            }
        }



    }
}
