using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    public float timer;
    private float t = 1;
    public int force;
    public GameObject Bottom;

    void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            t = timer;
            Vector3 direction = transform.position - Bottom.transform.position;
            GetComponent<Rigidbody>().velocity = direction * force;
        }
    }
}
