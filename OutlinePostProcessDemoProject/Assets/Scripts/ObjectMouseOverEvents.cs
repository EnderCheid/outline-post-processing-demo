using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectMouseOverEvents : MonoBehaviour
{
    public UnityEvent ObjMouseEnter;
    public UnityEvent ObjMouseOver;
    public UnityEvent ObjMouseExit;

    private void OnMouseEnter()
    {
        ObjMouseEnter.Invoke();
    }

    private void OnMouseOver()
    {
        ObjMouseOver.Invoke();
    }

    private void OnMouseExit()
    {
        ObjMouseExit.Invoke();
    }
}
