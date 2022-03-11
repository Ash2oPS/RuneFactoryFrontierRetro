using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class OnClick : Interactable
{
    protected virtual void OnMouseDown()
    {
        Interact();
    }

    protected virtual void OnMouseEnter()
    {
        
    }

    protected virtual void OnMouseExit()
    {

    }
}
