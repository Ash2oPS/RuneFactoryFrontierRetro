using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOptiUpdate : MonoBehaviour
{
    #region PrivateVariables

    public int nombreDeCoroutines;

    //private Type _maVariable;

    #endregion PrivateVariables

    private void Start()
    {
        Test();
    }

    private void Update()
    {
        Test();
    }

    private void Test()
    {
        nombreDeCoroutines++;
        Debug.Log("delta time = " + Time.deltaTime + " - nombre de boucles actuel = " + nombreDeCoroutines);
        Test();
    }
}