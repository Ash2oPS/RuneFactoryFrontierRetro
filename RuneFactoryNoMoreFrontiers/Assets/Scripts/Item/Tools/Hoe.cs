using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "new_Hoe", menuName = "Item/Tool/Hoe", order = 0)]
public class Hoe : Tool
{
    public override void SetDelegate(UseItem delegateScript)
    {
        delegateScript.fieldTileAction = this.HoeTile;
    }

    public void HoeTile(FieldTile tile)
    {
        if (tile == null || tile.State != FieldTileState.empty)
            return;

        tile.HoeTile();
    }
}