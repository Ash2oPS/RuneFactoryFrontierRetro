using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InventoryItem
{
    public Item item;
    public int nbItem;

    public InventoryItem(Item item, int nbItem)
    {
        this.item = item;
        this.nbItem = nbItem;
    }

    public void setNbItem(int value)
    {
        nbItem = value;
    }
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
    private int _maxHp, _maxRp, _atk, _mag, _def, _magDef, _firePower, _fireRes, _waterPower, _waterRes, _earthPower, _earthRes, _windPower, _windRes, _lightPower, _lightRes, _darknessPower, _darknessRes;

    public int MaxHp { get => _maxHp; }
    public int MaxRp { get => _maxRp; }
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

    public string ToStringStats()
    {
        return
            "Max HP : " + MaxHp.ToString() + "\n" +
            "Max RP : " + MaxRp.ToString() + "\n" +
            "ATK : " + Atk.ToString() + "\n" +
            "MAG : " + Mag.ToString() + "\n" +
            "DEF : " + Def.ToString() + "\n" +
            "MAGDEF : " + MagDef.ToString();
    }

    public string ToStringMagic(out int index)
    {
        return LineReturnText(out index, "Fire Power : " + FirePower.ToString(),
            "Fire Resistance : " + FireRes.ToString(),
            "Water Power : " + WaterPower.ToString(),
            "Water Resistance : " + WaterRes.ToString(),
            "Earth Power : " + EarthPower.ToString(),
            "Earth Resistance : " + EarthRes.ToString(),
            "Wind Power : " + WindPower.ToString(),
            "Wind Resistance : " + WindRes.ToString(),
            "Light Power : " + LightPower.ToString(),
            "Light Resistance : " + LightRes.ToString(),
            "Darkness Power : " + DarknessPower.ToString(),
            "Darkness Resistance : " + DarknessRes.ToString());

        //return
        //"Fire Power : " + FirePower.ToString() + "\n" +
        //"Fire Resistance : " + FireRes.ToString() + "\n" +
        //"Water Power : " + WaterPower.ToString() + "\n" +
        //"Water Resistance : " + WaterRes.ToString() + "\n" +
        //"Earth Power : " + EarthPower.ToString() + "\n" +
        //"Earth Resistance : " + EarthRes.ToString() + "\n" +
        //"Wind Power : " + WindPower.ToString() + "\n" +
        //"Wind Resistance : " + WindRes.ToString() + "\n" +
        //"Light Power : " + LightPower.ToString() + "\n" +
        //"Light Resistance : " + LightRes.ToString() + "\n" +
        //"Darkness Power : " + DarknessPower.ToString() + "\n" +
        //"Darkness Resistance : " + DarknessRes.ToString() + "\n";
    }

    private string LineReturnText(out int numberOfLines, params string[] lines)
    {
        var index = 0;
        var ret = string.Empty;
        foreach (var item in lines)
        {
            index++;
            ret += item + "\n";
        }
        ret = ret.Remove(ret.Length - 1);

        numberOfLines = index;
        return ret;
    }
}