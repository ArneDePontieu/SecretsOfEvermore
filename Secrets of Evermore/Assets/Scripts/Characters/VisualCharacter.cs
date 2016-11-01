using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public Avatar info;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    //----------------------
    //PUBLIC METHODS
    //----------------------

    public void Update()
    {
        if (info != null)
        {
            Move();
        }
    }

    public void Move()
    {

        //Get the postition
        var pos = transform.position;

        //Move with keys if IsSelected is true, otherwise move automatically    
        if (info.IsSelected)
        {
            /*
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pos.x -= info.MovementSpeed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pos.x += info.MovementSpeed * Time.deltaTime;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pos.y += info.MovementSpeed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos.y -= info.MovementSpeed * Time.deltaTime;
            }
            */
            var move = new Vector3();
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            transform.position += move * info.MovementSpeed * Time.deltaTime;
        }
        else
        {
            //autofollow
        }

        transform.position = pos;


    }
}
