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

    private InventoryItem _selectedItem;

    private List<ImageContainer> _allInventoryImages;

    [SerializeField]
    private UI_SelectionCursor _selectionCursor;

    #endregion PrivateVariables

    #region GettersAndSetters

    public List<InventoryItem> Inventory { get => _inventory; }

    public InventoryItem SelectedItem { get => _selectedItem; }

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

        SwitchSelectedItem(0);
    }

    public void SwitchSelectedItem(int index)
    {
        _selectedItem = _inventory[index];
        StartCoroutine(MoveSelectionCursor());
    }

    private IEnumerator MoveSelectionCursor()
    {
        float lerpT = 0;
        RectTransform rt = _selectionCursor.GetComponent<RectTransform>();
        RectTransform rtNew = null;
        for (int i = 0; i < _allInventoryImages.Count; i++)
        {
            if (_allInventoryImages[i].InventoryItem == SelectedItem)
            {
                rtNew = _allInventoryImages[i].GetComponent<RectTransform>();
            }
        }

        Vector2 previousPos = new Vector2(rt.position.x, rt.position.y);
        Vector2 newPos = new Vector2(rtNew.position.x, rtNew.position.y);
        rt.position = new Vector2();
        while (lerpT < 1)
        {
            rt.position = Vector2.Lerp(previousPos, newPos, lerpT);
            lerpT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion Functions
}