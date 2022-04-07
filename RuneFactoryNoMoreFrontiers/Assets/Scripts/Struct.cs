using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InventoryItem
{
    public Item item;
    public int nbItem;
}

[Serializable]
public struct Level
{
    public string levelName;
    public int levelNumber;
    public float levelProgression;

    public Level(string levelName, int levelNumber) : this()
    {
        this.levelName = levelName;
        this.levelNumber = levelNumber;
    }
}

[Serializable]
public struct Stats
{
    [SerializeField]
    private int _maxHp, _hp, _maxRp, _rp, _atk, _mag, _def, _magDef, _firePower, _fireRes, _waterPower, _waterRes, _earthPower, _earthRes, _windPower, _windRes, _lightPower, _lightRes, _darknessPower, _darknessRes;

    public int MaxHp { get => _maxHp; }
    public int Hp { get => _hp; }
    public int MaxRp { get => _maxRp; }
    public int Rp { get => _rp; }
    public int Atk { get => _atk; }
    public int Mag { get => _mag; }
    public int Def { get => _def; }
    public int MagDef { get => _magDef; }
    public int FirePower { get => _firePower; }
    public int FireRes { get => _fireRes; }
    public int WaterPower { get => _waterPower; }
    public int WaterRes { get => _waterRes; }
    public int EarthPower { get => _earthPower; }
    public int EarthRes { get => _earthRes; }
    public int WindPower { get => _windPower; }
    public int WindRes { get => _windRes; }
    public int LightPower { get => _lightPower; }
    public int LightRes { get => _lightRes; }
    public int DarknessPower { get => _darknessPower; }
    public int DarknessRes { get => _darknessRes; }
}