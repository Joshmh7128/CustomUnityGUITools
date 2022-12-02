using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomGizmo))]
public class CustomGizmoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CustomGizmo targetScript = target as CustomGizmo;


        if (targetScript.GizmoType == CustomGizmo.GizmoTypes.Box)
        {
            targetScript.boxSize = EditorGUILayout.Vector3Field("Box Size", targetScript.boxSize);
            targetScript.boxColor = EditorGUILayout.ColorField("Box Color", targetScript.boxColor);
        }

        if (targetScript.GizmoType == CustomGizmo.GizmoTypes.Sphere)
        {
            targetScript.radius = EditorGUILayout.IntSlider("Sphere Radius", targetScript.radius, 0, 4);
            targetScript.sphereColor = EditorGUILayout.ColorField("Sphere Color", targetScript.sphereColor);
        }

        if (targetScript.GizmoType == CustomGizmo.GizmoTypes.Line)
        {
            targetScript.startPoint = (GameObject)EditorGUILayout.ObjectField("Start Point", targetScript.startPoint, typeof(GameObject), true);
            targetScript.endPoint = (GameObject)EditorGUILayout.ObjectField("End Point", targetScript.endPoint, typeof(GameObject), true);
            targetScript.lineColor = EditorGUILayout.ColorField("Sphere Color", targetScript.lineColor);
        }

        if (targetScript.GizmoType == CustomGizmo.GizmoTypes.Word)
        {
            targetScript.wordObject = (GameObject)EditorGUILayout.ObjectField("Word Object", targetScript.wordObject, typeof(GameObject), true);
            targetScript.word = EditorGUILayout.DelayedTextField("Word Text", targetScript.word);
        } 

    }
}