using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    public float MaxAngleDeflection = 30.0f;
    public float SpeedOfPendulum = 1.0f;

    private void Update()
    {
      

        float angle = MaxAngleDeflection * Mathf.Sin(Time.time * SpeedOfPendulum);
        this.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
