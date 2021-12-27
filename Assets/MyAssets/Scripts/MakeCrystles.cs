using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCrystles : MonoBehaviour
{
    public GameObject crystlePrefab, player;
    public int yPos = 1;
    public List<Transform> crystles;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    public void MakeCrystle()
    {
        print(yPos);

        var obj = Instantiate(crystlePrefab, transform.position, transform.rotation).transform;
        crystles.Add(obj);

        obj.transform.parent = player.transform.GetChild(0).transform;
        obj.transform.localPosition = new Vector3(0, yPos, 0);

        obj.transform.localScale = new Vector3(1,1,1);

        yPos++ ;

    }
}
