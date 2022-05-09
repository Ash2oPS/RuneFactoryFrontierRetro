using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : SpriteOnClick
{
    #region PrivateVariables

    private TimeManager _tm;
    //private VariableType _myVariable;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public VariableType MyVariable { get => _myVariable; set => _myVariable = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _tm = FindObjectOfType<TimeManager>();
    }

    protected override void Interact()
    {
        Sleep();
    }

    #endregion InheritedFunctions

    #region Functions

    private void Sleep()
    {
        if (_tm.Hour < 3)
        {
            _tm.NextDay(8);
        }
        else
        {
            _tm.NextDay(6);
        }

        DisplayInformation("Slept", Color.cyan);
    }

    #endregion Functions
}