using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;
    private bool i = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (i)
        {
            if (TimeToExplosion >= 0)
                TimeToExplosion -= Time.deltaTime;

            if (TimeToExplosion <= 0)
                Boom();
        }
    }

    void Boom()
    {
        i = false;

        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody B in blocks)
        {
            if(Vector3.Distance(transform.position, B.transform.position) < Radius)
            {
                Vector3 direction = B.transform.position - transform.position;

                float D = Vector3.Distance(transform.position, B.transform.position);

                B.AddForce(direction.normalized * Power * (Radius - D), ForceMode.Impulse);
            }
        }
    }
}

