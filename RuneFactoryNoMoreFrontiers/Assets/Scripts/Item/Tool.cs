using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tool : Item
{
    protected Tool()
    {
        isStackable = false;
    }

    [Header("Tool Part")]
    public int rpCost;

    public int skillPoints;
    public UnityEvent mainAction, superAction;
}