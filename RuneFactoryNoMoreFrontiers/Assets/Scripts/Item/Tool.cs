using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tool : Item
{
    [Header("Tool Part")]
    private bool isStackable = false;

    protected int rpCost;
    protected int skillPoints;
    protected UnityEvent mainAction, superAction;
}