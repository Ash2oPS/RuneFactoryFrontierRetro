using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    #region PrivateVariables

    private PlayerManager _pm;

    [SerializeField]
    private List<InventoryItem> _inventory;

    [SerializeField]
    private RectTransform _inventoryContainer;

    [SerializeField]
    private ImageContainer _imagesUIPrefab;

    private InventoryItem _selectedItem;

    private int _selectedItemIndex;

    private List<ImageContainer> _allInventoryImages;

    [SerializeField]
    private UI_SelectionCursor _selectionCursor;

    private UseItem _ui;

    #endregion PrivateVariables

    #region GettersAndSetters

    public List<InventoryItem> Inventory { get => _inventory; }

    public InventoryItem SelectedItem { get => _selectedItem; }

    #endregion GettersAndSetters

    #region InheritedFunctions

    private void Awake()
    {
        _pm = GetComponent<PlayerManager>();
        //UseItem.instance.useAction = ElPolloLoco;
    }

    private void Start()
    {
        _allInventoryImages = new List<ImageContainer>();
        _ui = FindObjectOfType<UseItem>();
        DisplayInventoryUI(true);
        SwitchSelectedItem(_selectedItemIndex, false);
    }

    /*public void ElPolloLoco()
    {
    }*/

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
            _selectionCursor.gameObject.SetActive(true);
            SwitchSelectedItem(_selectedItemIndex, false);
        }
        else
        {
            _selectionCursor.gameObject.SetActive(false);
            for (int i = 0; i < _allInventoryImages.Count; i++)
            {
                Destroy(_allInventoryImages[i].gameObject);
            }
            _allInventoryImages.Clear();
            _inventoryContainer.gameObject.SetActive(false);
        }
    }

    public void ModifyInventory(Item item, int numberToAdd)
    {
        if (item == null)
        {
            return;
        }

        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].item == item)
            {
                Inventory[i].setNbItem(Inventory[i].nbItem + numberToAdd);
                if (Inventory[i].nbItem < 1)
                {
                    Inventory.RemoveAt(i);
                }
                UpdateInventoryUI();
                return;
            }
        }
        InventoryItem itemToAdd = new InventoryItem(item, numberToAdd);
        Inventory.Add(itemToAdd);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        string log = "Oupse j'arrive pas à update mon hud :D\nCela dit, tu as :\n";

        for (int i = 0; i < Inventory.Count; i++)
        {
            log += "- ";
            log += Inventory[i].nbItem.ToString() + " ";
            log += Inventory[i].item.name;
            log += "\n";
        }

        Debug.Log(log);
    }

    public void SwitchSelectedItem(int index, bool isAnimated)
    {
        _selectedItemIndex = index;
        StopCoroutine(MoveSelectionCursor(index, isAnimated));
        StartCoroutine(MoveSelectionCursor(index, isAnimated));
        _selectedItem = _allInventoryImages[index].InventoItem;
    }

    private IEnumerator MoveSelectionCursor(int index, bool isAnimated)
    {
        float lerpT = 0;
        RectTransform rt = _selectionCursor.GetComponent<RectTransform>();
        Vector2 previousPos = new Vector2(rt.position.x, rt.position.y);

        if (isAnimated)
        {
            while (lerpT <= 1)
            {
                RectTransform rtNew = _allInventoryImages[index].GetComponentInChildren<RectTransform>();
                Vector2 newPos = new Vector2(rtNew.position.x, rtNew.position.y);
                lerpT += Time.deltaTime * 20;
                rt.position = Vector2.Lerp(previousPos, newPos, lerpT);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            SetToTransparent(_selectionCursor.GetComponent<Image>(), true);
            yield return new WaitForEndOfFrame();
            RectTransform rtNew = _allInventoryImages[index].GetComponentInChildren<RectTransform>();
            Vector2 newPos = new Vector2(rtNew.position.x, rtNew.position.y);
            rt.position = newPos;
            SetToTransparent(_selectionCursor.GetComponent<Image>(), false);
        }
    }

    public void SwitchSelectedItemAddedIndex(int addedIndex)
    {
        if (!_pm.IsMenuOpened)
        {
            _selectedItemIndex += addedIndex;
            if (_selectedItemIndex > -1 && _selectedItemIndex < _inventory.Count)
            {
                SwitchSelectedItem(_selectedItemIndex, true);
            }
            else
            {
                _selectedItemIndex -= addedIndex;
            }
            _ui.SetCurrentItem(SelectedItem.item);
        }
    }

    private void SetToTransparent(Image image, bool value)
    {
        float r = image.color.r;
        float g = image.color.g;
        float b = image.color.b;
        float a = 0;

        if (!value)
        {
            a = 1;
        }

        image.color = new Vector4(r, g, b, a);
    }

    #endregion Functions
}