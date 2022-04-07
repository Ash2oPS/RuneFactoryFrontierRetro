using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerManager))]
public class PlayerManager_Editor : Editor
{
    private SerializedProperty sp_playerStats;
    private SerializedProperty sp_maxHp, sp_struct, sp_maxRp, sp_atk, sp_mag, sp_def, sp_magDef, sp_firePower, sp_waterPower, sp_earthPower, sp_windPower, sp_lightPower, sp_darknessPower;

    private bool statTab, magicTab, skillTab;
    private int _tab;
    private GUIStyle _myStyle;

    private void OnEnable()
    {
        sp_playerStats = serializedObject.FindProperty("PlayerStats");
        sp_struct = serializedObject.FindProperty("_playerTrueStats");
        _myStyle = new GUIStyle();
        _myStyle.alignment = TextAnchor.MiddleCenter;
        _myStyle.normal.textColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        //sp_maxHp = sp_struct.FindPropertyRelative("_maxHp");
        //sp_maxRp = sp_struct.FindPropertyRelative("_maxRp");
        //sp_atk = sp_struct.FindPropertyRelative("_atk");
        //sp_maxHp = serializedObject.FindProperty("MaxHp");
        //sp_maxRp = serializedObject.FindProperty("MaxRp");
        //sp_atk = serializedObject.FindProperty("Atk");
        //sp_mag = serializedObject.FindProperty("Mag");
        //sp_def = serializedObject.FindProperty("Def");
        //sp_magDef = serializedObject.FindProperty("MagDef");
        //sp_firePower = serializedObject.FindProperty("FirePower");
        //sp_waterPower = serializedObject.FindProperty("WaterPower");
        //sp_earthPower = serializedObject.FindProperty("EarthPower");
        //sp_windPower = serializedObject.FindProperty("WindPower");
        //sp_lightPower = serializedObject.FindProperty("LightPower");
        //sp_darknessPower = serializedObject.FindProperty("DarknessPower");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        //statTab = EditorGUILayout.Foldout(statTab, "Classic Stats", true);
        //if (statTab)
        //{
        //    //DefaultDisplayEGL(sp_atk, sp_maxHp, sp_maxRp);
        //}

        //magicTab = EditorGUILayout.Foldout(magicTab, "Magic Stats", true);
        //if (magicTab)
        //{
        //    EditorGUILayout.LabelField((serializedObject.targetObject as PlayerManager).PlayerTrueStats.ToStringMagic(), GUILayout.Height(170));
        //}
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Stats", EditorStyles.miniButtonLeft))
        {
            _tab = 0;
        }
        if (GUILayout.Button("Magic", EditorStyles.miniButtonRight))
        {
            _tab = 1;
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical("box");
        switch (_tab)
        {
            default:
                StatGUI();
                break;

            case 1:
                MagicGUI();
                break;
        }
        EditorGUILayout.EndVertical();

        _myStyle.normal.textColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        if (GUILayout.Button("Randomizator"))
        {
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void DefaultDisplayEGL(params SerializedProperty[] sps)
    {
        foreach (var item in sps)
        {
            EditorGUILayout.PropertyField(item);
        }
    }

    private void StatGUI()
    {
        EditorGUILayout.LabelField((serializedObject.targetObject as PlayerManager).PlayerTrueStats.ToStringStats(), _myStyle, GUILayout.Height(100));
    }

    private void MagicGUI()
    {
        Debug.Log(EditorGUIUtility.standardVerticalSpacing);
        EditorGUILayout.LabelField((serializedObject.targetObject as PlayerManager).PlayerTrueStats.ToStringMagic(out int i), _myStyle, GUILayout.Height(i * EditorGUIUtility.singleLineHeight));
    }
}