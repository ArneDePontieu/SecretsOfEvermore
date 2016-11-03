using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{

    //PUBLIC VARIABLES
    public bool TriggerOnce;
    public List<GameObject> TriggerLinks;

    //PRIVATE VARIABLES

    //Delegate for the actions
    private delegate void UpdateAction();
    UpdateAction _action;

    //PRIVATE METHODS
    void Update()
    {
        if(_action!=null)
        {
            _action();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _action = null;

        foreach (var link in TriggerLinks)
        {
            _action += link.GetComponent<MovingObject>().Open;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!TriggerOnce)
        {
            _action = null;

            foreach (var link in TriggerLinks)
            {
                _action += link.GetComponent<MovingObject>().Close;
            }
        }
    }
}
