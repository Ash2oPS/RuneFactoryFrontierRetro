using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField]
    private List<InventoryItem> _inventory;

    [SerializeField]
    private RectTransform _inventoryContainer;

    [SerializeField]
    private ImageContainer _imagesUIPrefab;

    private List<ImageContainer> _allInventoryImages;

    #endregion PrivateVariables

    #region GettersAndSetters

    public List<InventoryItem> Inventory { get => _inventory; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Start()
    {
        DisplayInventoryUI();
    }

    private void Update()
    {
    }

    #endregion InheritedFunctions

    #region Functions

    public void DisplayInventoryUI()
    {
        _allInventoryImages = new List<ImageContainer>();
        if (_inventoryContainer.childCount < _inventory.Count)
        {
            for (int i = _inventoryContainer.childCount; i < _inventory.Count; i++)
            {
                var _image = Instantiate(_imagesUIPrefab, _inventoryContainer);
                _allInventoryImages.Add(_image);
            }
        }
        if (_inventoryContainer.childCount > _inventory.Count)
        {
            for (int i = _inventoryContainer.childCount; i >= _inventory.Count; i--)
            {
                Destroy(_allInventoryImages[0].gameObject);
                _allInventoryImages.RemoveAt(0);
            }
        }

        var j = 0;
        foreach (var item in _inventory)
        {
            _allInventoryImages[j].SetUI(item);
            j++;
        }
    }

    #endregion Functions
}