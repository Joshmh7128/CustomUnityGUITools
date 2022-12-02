using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomGizmo : MonoBehaviour
{
    public enum GizmoTypes
    {
        Off, Box, Line, Sphere, Word
    }

    [HideInInspector] public Vector3 boxSize;
    [HideInInspector] public GameObject startPoint, endPoint;

    [HideInInspector] public int radius; // the radius we use to draw our spheres

    [HideInInspector] public Color boxColor, lineColor, sphereColor;

    [HideInInspector] public GameObject wordObject;
    [HideInInspector] public string word;

    public GizmoTypes GizmoType; // what type of gizmo are we?

    private void OnDrawGizmos()
    {
        Gizmos.color = boxColor;

        if (GizmoType == GizmoTypes.Box)
        {
            try { Gizmos.DrawCube(transform.position, boxSize); } catch { }
        }

        Gizmos.color = lineColor;

        if (GizmoType == GizmoTypes.Line)
        {
            try { Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position); } catch { }
        }

        Gizmos.color = sphereColor;

        if (GizmoType == GizmoTypes.Sphere)
        {
            try { Gizmos.DrawSphere(transform.position, radius); } catch { }
        }

        // words
        if (GizmoType == GizmoTypes.Word)
        {
            try { wordObject.gameObject.SetActive(true); wordObject.name = word; } catch { }
        } else { wordObject.gameObject.SetActive(false); }
    }

}
