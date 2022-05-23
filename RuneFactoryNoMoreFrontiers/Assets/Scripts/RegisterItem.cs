using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterItem : MonoBehaviour
{
    public UseItem refItem;

    private Item currentItem;

    public Item CurrentItem
    {
        set
        {
            currentItem = value;
            currentItem.RegisterItem(refItem);
        }
    }
}