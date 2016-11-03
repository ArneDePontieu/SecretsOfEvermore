using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{

    //PUBLIC VARIABLES
    public float MoveSpeed;

    public bool IsMoving;

    public Vector3 OpenPosition;
    public Vector3 ClosedPosition;

    //PRIVATE VARIABLES
    private Vector3 _distanceVector;

    //PUBLIC METHODS
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

}
