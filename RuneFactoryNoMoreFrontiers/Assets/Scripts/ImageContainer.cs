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
    //private Type _maVariable;

    #endregion PrivateVariables

    #region Functions

    public void SetUI(InventoryItem inevntoryItem)
    {
        _image.sprite = inevntoryItem.item.itemSprite;
        if (inevntoryItem.item.isStackable)
        {
            _text.text = inevntoryItem.nbItem.ToString("00");
        }
    }

    #endregion Functions
}