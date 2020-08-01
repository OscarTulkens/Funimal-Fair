using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawConnectionScript))]
public class EDITORDrawConnectionScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DrawConnectionScript _drawConnectionScript = (DrawConnectionScript)target;
        if (GUILayout.Button("Update Lines"))
        {

            foreach (DrawConnectionScript dcs in GameObject.FindObjectsOfType<DrawConnectionScript>())
            {
                dcs.UpdateTileConnection();
            }
        }
    }
}
