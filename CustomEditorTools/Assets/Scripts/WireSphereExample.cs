using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSphereExample : MonoBehaviour
{
    [SerializeField] float radius; // the radius of our sphere

    [SerializeField] float randomNum;

    private void Start()
    {
        radius = Random.value * 100f;
        gameObject.name = radius.ToString();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
