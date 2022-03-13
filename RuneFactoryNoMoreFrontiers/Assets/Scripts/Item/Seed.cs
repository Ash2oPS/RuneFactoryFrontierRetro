using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_SeedItem", menuName = "Item/Seed", order = 1)]
public class Seed : Item
{
    [Header("Seed Part")]
    public int daysToHarvest;

    public int timeToHarvestAgain;
    public List<season> seasons;
    public Harvest correspondingHarvest;
    public seedType seedType;
}