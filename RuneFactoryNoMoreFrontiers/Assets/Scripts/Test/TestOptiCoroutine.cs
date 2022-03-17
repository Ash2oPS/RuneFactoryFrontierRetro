using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOptiCoroutine : MonoBehaviour
{
    #region PrivateVariables

    public int nombreDeCoroutines;
    public int coroutinesToSpawn = 100;

    //private Type _maVariable;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

    #endregion GettersAndSetters

    private void Start()
    {
        StartCoroutine(MyDebug());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coroutinesToSpawn++;
        }
    }

    private IEnumerator MyDebug()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < coroutinesToSpawn; i++)
            {
                Debug.Log("Coucou");
            }
        }
    }
}