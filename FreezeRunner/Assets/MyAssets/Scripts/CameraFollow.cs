using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float offsetX, offsetY;
    public bool camY;

    void Update()
    {
        if (camY)
        {
            this.transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x + offsetX, transform.position.y, transform.position.z);
        }
    }
}
