using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_EatableItem", menuName = "Item/Eatable", order = 2)]
public class Eatable : Item
{
    public int restoredHP, restoredRP;
}