using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystle : MonoBehaviour
{
    public GameObject player;
    public float crystleSpeed;
    public Transform crystlePos;
    
    void Start()
    {
      //  crystlePos = new Vector3(0, 0.55f, -0.22f);
      //  MoveCrystlePose();
    }

    public void MoveCrystlePose()
    {
       // crystlePos = new Vector3(crystlePos.x, crystlePos.y + 0.25f, crystlePos.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, crystlePos.position, Time.deltaTime * crystleSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Invoke("Destroy", 1);
        //    Destroy(GetComponent<BoxCollider>());
        //}

        if (other.gameObject.CompareTag("Crystle"))
        {
            other.gameObject.GetComponent<MakeCrystles>().MakeCrystle();
            Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
