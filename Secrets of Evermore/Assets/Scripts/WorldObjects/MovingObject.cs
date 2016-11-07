using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingObject : MonoBehaviour
{

    //----------------------
    //PUBLIC VARIABLES
    //----------------------

    public float MoveSpeed;

    public bool IsMoving;
    public bool IsOpening = false;

    public List<int> ActivatedTriggersID = new List<int>();

    public Vector3 OpenPosition;
    public Vector3 ClosedPosition;

    //----------------------
    //PRIVATE VARIABLES
    //----------------------

    private Vector3 _distanceVector;

    //----------------------
    //PRIVATE METHODS
    //----------------------

    void Update()
    {
        if (IsOpening)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    //----------------------
    //PUBLIC METHODS
    //----------------------

    //Put the object in the closed position
    public void Close()
    {
        if (IsMoving)
        {
            _distanceVector = ClosedPosition - this.transform.localPosition;
            if (_distanceVector.magnitude <= 0.01f)
            {
                IsMoving = false;
            }
            else
            {
                this.transform.localPosition = this.transform.localPosition + _distanceVector.normalized * MoveSpeed * Time.deltaTime;
            }
        }
    }

    //Put the object in the open position
    public void Open()
    {
        if (IsMoving)
        {
            _distanceVector = OpenPosition - this.transform.localPosition;
            if (_distanceVector.magnitude <= 0.01f)
            {
                IsMoving = false;
            }
            else
            {
                this.transform.localPosition = this.transform.localPosition + _distanceVector.normalized * MoveSpeed * Time.deltaTime;
            }
        }
    }

    //Add an activated trigger, this is a counter for multiple triggers
    public void AddActivatedTrigger(int ID)
    {
        //Set moving and opening to true
        IsMoving = true;
        IsOpening = true;

        //bool to check if the trigger already exists in the list
        bool add = true;

        foreach (var t in ActivatedTriggersID)
        {
            //USE Id's to check if they're different
            if (t == ID)
            {
                add = false;
            }
        }

        //Add the object if it doesn't exist in the list already
        if (add)
        {
            ActivatedTriggersID.Add(ID);
        }
    }

    //Remove an activated trigger
    public void RemoveActivatedTrigger(int ID)
    {
        //bool to check if the trigger already exists in the list
        bool remove = false;

        foreach (var t in ActivatedTriggersID)
        {
            //USE Id's to check if they're different
            if (t == ID)
            {
                remove = true;
            }
        }

        //Remove the object if it exists in the list
        if (remove)
        {
            ActivatedTriggersID.Remove(ID);
        }

        if (ActivatedTriggersID.Count <= 0)
        {
            IsMoving = true;
            IsOpening = false;
        }
    }
}
