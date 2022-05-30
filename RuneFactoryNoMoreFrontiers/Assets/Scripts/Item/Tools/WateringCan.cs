using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_WateringCan", menuName = "Item/Tool/Watering Can", order = 0)]
public class WateringCan : Tool
{
    public int waterCount;

    public override void SetDelegate(UseItem delegateScript)
    {
        delegateScript.fieldTileAction = this.WaterTile;
    }

    public void WaterTile(FieldTile tile)
    {
        if (tile == null || tile.IsWatered)
            return;

        tile.WaterTile();
    }
}