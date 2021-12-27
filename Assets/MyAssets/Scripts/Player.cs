using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public float speed, downForce;
    public CharacterController cc;
    public Transform crystlePos;
    public Animator anim;
    public GameObject winPanel, retryPanel, winParticle;
    
    private void Start()
    {

    }

    void Update()
    {
        Vector3 vec = new Vector3(speed*Time.deltaTime, downForce, 0);

        cc.Move(vec);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("Ground");
            //anim.SetBool("isSurfing", false);
            anim.SetBool("Run", true);
        }

      
        if (collision.gameObject.CompareTag("Spike"))
        {
            print("Retry");
            anim.SetBool("Death", true);
            speed = 0;

            collision.gameObject.tag = "Untagged";

            FindObjectOfType<RoadDrawManager>().enabled = false;

            GameManager.Instance.GetComponent<AudioSource>().Play();
            GameManager.Instance.RetryGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (winPanel.activeSelf == false && retryPanel.activeSelf == false)
            {

                anim.SetBool("Dance", true);

                Invoke("InvokeWinGame", 1);
            }
        }
    }

    public void InvokeWinGame()
    {
        print("Win");
        winParticle.SetActive(true);
        winPanel.SetActive(true);
        speed = 0;
    }
}
