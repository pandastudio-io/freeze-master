using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystleCollecter : MonoBehaviour
{
    public LayerMask layerMask;
    public float crystleRayHeight;
    public Transform player;
    public Vector3 offset;
    public Vector3 offset1;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up)+offset, out hit, crystleRayHeight, layerMask))
        {
            print("CollectCrystle");

            hit.transform.gameObject.layer = default;
            hit.transform.GetComponent<Crystle>().crystlePos = player.transform;
            hit.transform.GetComponent<Crystle>().enabled = true;
        }

        RaycastHit hit1;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up)+offset1, out hit1, crystleRayHeight, layerMask))
        {
            print("CollectCrystle");

            hit1.transform.gameObject.layer = default;
            hit1.transform.GetComponent<Crystle>().crystlePos = player.transform;
            hit1.transform.GetComponent<Crystle>().enabled = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) +offset* crystleRayHeight;
        Gizmos.DrawRay(transform.position, direction);

   
        Vector3 direction1 = transform.TransformDirection(Vector3.up)+ offset1 * crystleRayHeight;
        Gizmos.DrawRay(transform.position, direction1);
    }
}
