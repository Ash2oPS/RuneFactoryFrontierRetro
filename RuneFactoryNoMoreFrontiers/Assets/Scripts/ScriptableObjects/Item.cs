using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_BaseItem", menuName = "Item/Base_Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("Item Part")]
    public string itemName;

    public string itemDescription;
    public Sprite itemSprite;
    public float itemBuyingPrice, itemSellingPrice;
    public bool isStackable = true;

    public virtual void SetDelegate(UseItem delegateScript)
    {
        delegateScript.fieldTileAction = null;
    }

    public virtual void DefaultFieldTileAction(FieldTile tile)
    {
    }

    public virtual void RegisterItem(UseItem useItem)
    {
        useItem.fieldTileAction = DefaultFieldTileAction;
    }
}