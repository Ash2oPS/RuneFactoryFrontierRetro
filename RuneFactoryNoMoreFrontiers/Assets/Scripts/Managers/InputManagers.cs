using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManagers : MonoBehaviour
{
    #region PublicVariables

    public KeyCode moveUpInput, moveDownInput, moveLeftInput, moveRightInput, menuInput;

    public UnityEvent moveUp, moveDown, moveLeft, moveRight, menu;

    #endregion PublicVariables

    private void Start()
    {
        //StartCoroutine(InputListener());
    }

    private void Update()
    {
        if (Input.GetKeyDown(menuInput))
        {
            menu.Invoke();
        }
    }

    private IEnumerator InputListener()
    {
        while (true)
        {
            if (Input.GetKey(moveUpInput))
            {
                moveUp.Invoke();
            }
            else if (Input.GetKey(moveDownInput))
            {
                moveDown.Invoke();
            }

            if (Input.GetKey(moveLeftInput))
            {
                moveLeft.Invoke();
            }
            else if (Input.GetKey(moveRightInput))
            {
                moveRight.Invoke();
            }

            yield return new WaitForEndOfFrame();
        }
    }
}