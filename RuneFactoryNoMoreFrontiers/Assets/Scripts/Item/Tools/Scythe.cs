using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_Scythe", menuName = "Item/Tool/Scythe", order = 0)]
public class Scythe : Tool
{
    public override void SetDelegate(UseItem delegateScript)
    {
        delegateScript.fieldTileAction = this.CutTile;
    }

    public void CutTile(FieldTile tile)
    {
        if (tile == null || tile.State != FieldTileState.dried)
            return;

        tile.CutTile();
    }
}