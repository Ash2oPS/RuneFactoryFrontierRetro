using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventoryItem
{
    public Item item;
    public int nbItem;
}

[System.Serializable]
public struct Level
{
    public string levelName;
    public int levelNumber;
    public float levelProgression;
}