using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDetection : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private Collider2D col;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnClick onClick = null;
        collision.TryGetComponent<OnClick>(out onClick);
        if (onClick != null)
        {
            onClick.setCanBeSelected(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnClick onClick = null;
        collision.TryGetComponent<OnClick>(out onClick);
        if (onClick != null)
        {
            onClick.setCanBeSelected(false);
        }
    }

    #endregion Functions
}