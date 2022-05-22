using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Hoe", menuName = "Item/Tool/Hoe", order = 0)]
public class Hoe : Tool
{
    public override void SetDelegate(UseItem delegateScript)
    {
        FieldTile tile = null;
        delegateScript._usingItemDelegate = HoeTile(FieldTile tile);
    }

    public void HoeTile(FieldTile tile)
    {
        // a besoin de get la selected tile
        tile.HoeTile();
    }
}