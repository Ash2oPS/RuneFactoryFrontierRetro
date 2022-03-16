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
        _allInventoryImages = new List<ImageContainer>();
    }

    #endregion InheritedFunctions

    #region Functions

    public void DisplayInventoryUI(bool value)
    {
        if (value)
        {
            _inventoryContainer.gameObject.SetActive(true);

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

            for (int j = 0; j < _inventory.Count; j++)
            {
                _allInventoryImages[j].SetUI(_inventory[j]);
            }

            SwitchSelectedItem(1);
        }
        else
        {
            for (int i = 0; i < _allInventoryImages.Count; i++)
            {
                Destroy(_allInventoryImages[i].gameObject);
            }
            _allInventoryImages.Clear();
            _inventoryContainer.gameObject.SetActive(false);
        }
    }

    public void SwitchSelectedItem(int index)
    {
        StartCoroutine(MoveSelectionCursor(index));
        _selectedItem = _allInventoryImages[index].InventoItem;
    }

    private IEnumerator MoveSelectionCursor(int index)
    {
        float lerpT = 0;
        RectTransform rt = _selectionCursor.GetComponent<RectTransform>();
        RectTransform rtNew = _allInventoryImages[index].GetComponentInChildren<RectTransform>();

        Vector2 previousPos = new Vector2(rt.position.x, rt.position.y);
        Vector2 newPos = new Vector2(rtNew.position.x, rtNew.position.y);
        while (lerpT < 1)
        {
            rt.position = Vector2.Lerp(previousPos, newPos, lerpT);
            lerpT += Time.deltaTime * 5;
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion Functions
}