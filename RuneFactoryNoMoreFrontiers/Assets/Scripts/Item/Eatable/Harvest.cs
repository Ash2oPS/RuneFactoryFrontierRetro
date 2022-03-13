using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_HarvestItem", menuName = "Item/Eatable/Harvest", order = 0)]
public class Harvest : Eatable
{
    [Header("Harvest Part")]
    public Seed correspondingSeed;
}