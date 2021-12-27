using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
        this.transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
