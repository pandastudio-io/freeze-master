using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RoadCheck : MonoBehaviour
{
    public ParticleSystem destroyRoadParticle;
    public BoxCollider destroyRoadCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            print("RoadDestroy");
            destroyRoadParticle.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            destroyRoadCollider.center = new Vector3(destroyRoadCollider.center.x, 0.9f, destroyRoadCollider.center.z);
            destroyRoadCollider.size = new Vector3(destroyRoadCollider.size.x, 1.7f, destroyRoadCollider.size.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            destroyRoadCollider.center = new Vector3(destroyRoadCollider.center.x, 1.27f, destroyRoadCollider.center.z);
            destroyRoadCollider.size = new Vector3(destroyRoadCollider.size.x, 1.09f, destroyRoadCollider.size.z);
        }
    }
}
