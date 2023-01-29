using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hit : MonoBehaviour
{
    public float time;
    public float power;
    public Vector3 hit;

    private bool i = true;

    void Update()
    {
        if (i)
        {
            if (time > 0)
             time -= Time.deltaTime;
            if (time <= 0)
            {
                GetComponent<Rigidbody>().AddForce(hit * power, ForceMode.Impulse);
                i = false;
            }
        }
    }
}

