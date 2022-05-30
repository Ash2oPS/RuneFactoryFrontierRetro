using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseItem : MonoBehaviour
{
    #region PrivateVariables

    private PlayerManager _playerManager;

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

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _inventoryManager = FindObjectOfType<InventoryManager>();

        _currentItem = _inventoryManager.SelectedItem.item;
        SetCurrentItem(_currentItem);
    }

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
        if (!(_currentItem is Tool) && !(_currentItem is Seed))
        {
            return;
        }

        _currentItem.SetDelegate(this);
    }

    public void Use()
    {
        if (_playerManager.SelectedFieldTile != null && fieldTileAction != null)
            fieldTileAction.Invoke(_playerManager.SelectedFieldTile);
    }

    #endregion Functions
}