using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (MapGeneratorSB))]
public class MapGEEditorSB : Editor
{
    public override void OnInspectorGUI()
    {
        MapGeneratorSB mapGen = (MapGeneratorSB)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button("Letusdoit"))
        {
            mapGen.GenerateMap();
        }
    }
}
