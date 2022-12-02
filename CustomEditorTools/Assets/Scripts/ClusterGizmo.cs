using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterGizmo : MonoBehaviour
{
    [SerializeField] List<GameObject> clusters = new List<GameObject>();

    private void OnDrawGizmos()
    {
        foreach(var cluster in clusters)
        {
            Gizmos.DrawLine(transform.position, cluster.transform.position);
        }
    }
}
