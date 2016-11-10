using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(RoomGen))]
public class RoomGenEditor : Editor
{

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        RoomGen gen = (RoomGen)target;
        serializedObject.Update();

        gen.columns = EditorGUILayout.IntField("Columns", gen.columns);
        gen.rows = EditorGUILayout.IntField("Rows", gen.columns);
        //Width Min max Slider

        gen.w_min = EditorGUILayout.IntField("Min Width", gen.w_min);
        gen.w_max = EditorGUILayout.IntField("Max Width", gen.w_max);

        float w_min = gen.w_min;
        float w_max = gen.w_max;

        EditorGUILayout.MinMaxSlider(ref w_min, ref w_max, 0, gen.columns);

        gen.w_min = Mathf.RoundToInt(w_min);
        gen.w_max = Mathf.RoundToInt(w_max);

        //Height Min Max Slider


        gen.h_min = EditorGUILayout.IntField("Min Height", gen.h_min);
        gen.h_max = EditorGUILayout.IntField("Max Height", gen.h_max);

        float h_min = gen.h_min;
        float h_max = gen.h_max;

        EditorGUILayout.MinMaxSlider(ref h_min, ref h_max, 0, gen.rows);

        gen.h_min = Mathf.RoundToInt(h_min);
        gen.h_max = Mathf.RoundToInt(h_max);

        SerializedProperty floorTiles = serializedObject.FindProperty("floorTiles");
        EditorGUILayout.PropertyField(floorTiles, true);

        SerializedProperty wallTiles = serializedObject.FindProperty("wallTiles");
        EditorGUILayout.PropertyField(wallTiles, true);

        SerializedProperty outerWallTiles = serializedObject.FindProperty("outerWallTiles");
        EditorGUILayout.PropertyField(outerWallTiles, true);

        SerializedProperty enemies = serializedObject.FindProperty("enemies");
        EditorGUILayout.PropertyField(enemies, true);

        SerializedProperty exitSign = serializedObject.FindProperty("exitSign");
        EditorGUILayout.PropertyField(exitSign, true);

        SerializedProperty player = serializedObject.FindProperty("player");
        EditorGUILayout.PropertyField(player, true);

        SerializedProperty camera = serializedObject.FindProperty("camera");
        EditorGUILayout.PropertyField(camera, true);

        serializedObject.ApplyModifiedProperties();
    }
}
