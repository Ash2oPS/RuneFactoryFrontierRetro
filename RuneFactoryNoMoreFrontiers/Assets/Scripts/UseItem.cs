using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseItem : MonoBehaviour
{
    #region PrivateVariables

    private InventoryManager _inventoryManager;
    private Item _currentItem;

    public delegate void UseTool(FieldTile tile);

    public UseTool _usingItemDelegate;

    public UnityAction<FieldTile> fieldTileAction;

    #endregion PrivateVariables

    #region GettersAndSetters

    //public Type MaVariable { get => _maVariable; set => _maVariable = value; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Use();
        }
    }

    #endregion InheritedFunctions

    #region Functions

    public void SetCurrentItem(Item value)
    {
        _currentItem = value;
        if (_currentItem.GetType() != typeof(Tool))
        {
            return;
        }

        _currentItem.SetDelegate(this);
    }

    public void Use()
    {
        fieldTileAction.Invoke()
    }

    #endregion Functions
}