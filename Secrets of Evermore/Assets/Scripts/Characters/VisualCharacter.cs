using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private float _followDistance = 2.0f;
    private bool _isFollowing = false;

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

        if (SelectedChar != null)
        {
            //Distance between the character and the selecterdcharacter
            var distanceVector = GetDistanceVector(SelectedChar.transform.transform.position);

            //Follow if very far and come close
            if (_isFollowing)
            {
                if (distanceVector.magnitude < _followDistance)
                {
                    _isFollowing = false;
                }
            }
            else
            {
                if (distanceVector.magnitude > _followDistance+4.0f)
                {
                    _isFollowing = true;
                }
            }

            if(_isFollowing)
            {
                transform.position = transform.position + (distanceVector.normalized * Time.deltaTime * Info.MovementSpeed);
            }
        }

    }

    //PRIVATE METHODS
    private Vector3 GetDistanceVector(Vector3 target)
    {
        return target - transform.position;
    }
}
