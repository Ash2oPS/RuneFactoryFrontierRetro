using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImageContainer : MonoBehaviour
{
    #region PrivateVariables

    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    private InventoryItem _inventoItem;

    public InventoryItem InventoItem { get => _inventoItem; }

    //private Type _maVariable;

    #endregion PrivateVariables

    #region Functions

    public void SetUI(InventoryItem inventoryItem)
    {
        _inventoItem = inventoryItem;
        _image.sprite = inventoryItem.item.itemSprite;
        if (inventoryItem.item.isStackable)
        {
            _text.text = inventoryItem.nbItem.ToString("00");
        }
    }

    #endregion Functions
}