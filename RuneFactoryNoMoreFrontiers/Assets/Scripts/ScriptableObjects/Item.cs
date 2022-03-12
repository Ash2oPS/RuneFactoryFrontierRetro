using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_BaseItem", menuName = "Item/Base_Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName, itemDescription;
    public Sprite itemSprite;
    public float itemBuyingPrice, itemSellingPrice;
}