using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerManager))]
public class PlayerManager_Editor : Editor
{
    private SerializedProperty sp_playerStats;
    private SerializedProperty sp_maxHp, sp_maxRp, sp_atk, sp_mag, sp_def, sp_magDef, sp_firePower, sp_waterPower, sp_earthPower, sp_windPower, sp_lightPower, sp_darknessPower;

    private bool statTab, magicTab, skillTab;

    private void OnEnable()
    {
        sp_playerStats = serializedObject.FindProperty("PlayerStats");
        sp_maxHp = serializedObject.FindProperty("MaxHp");
        sp_maxRp = serializedObject.FindProperty("MaxRp");
        sp_atk = serializedObject.FindProperty("Atk");
        sp_mag = serializedObject.FindProperty("Mag");
        sp_def = serializedObject.FindProperty("Def");
        sp_magDef = serializedObject.FindProperty("MagDef");
        sp_firePower = serializedObject.FindProperty("FirePower");
        sp_waterPower = serializedObject.FindProperty("WaterPower");
        sp_earthPower = serializedObject.FindProperty("EarthPower");
        sp_windPower = serializedObject.FindProperty("WindPower");
        sp_lightPower = serializedObject.FindProperty("LightPower");
        sp_darknessPower = serializedObject.FindProperty("DarknessPower");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}