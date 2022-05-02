using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class OnClick : Interactable
{
    protected bool canBeSelected;

    public void setCanBeSelected(bool value)
    {
        canBeSelected = value;
    }

    protected virtual void OnMouseDown()
    {
        if (canBeSelected)
            Interact();
    }

    protected virtual void OnMouseEnter()
    {
    }

    protected virtual void OnMouseExit()
    {
    }
}