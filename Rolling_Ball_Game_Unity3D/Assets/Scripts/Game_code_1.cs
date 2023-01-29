using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_code_1 : MonoBehaviour
{

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform point6;
    public Transform point7;
    public Transform point8;

    public float speed;
    public bool go;
    public float power;

    private Vector3 target;
    private int pointNumber = 0;
    private int N = 7;

    void Start()
    {
        target = point1.position;
        transform.LookAt(target);
    }

    void Update()
    {       
        if (go)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
     
       if(transform.position == target)
       {                        
            if (pointNumber < N)
               pointNumber++;
                                    
            if (pointNumber == 0)
                target = point1.position;
            if (pointNumber == 1)
                target = point2.position;
            if (pointNumber == 2)
                target = point3.position;
            if (pointNumber == 3)
                target = point4.position;
            if (pointNumber == 4)
                target = point5.position;
            if (pointNumber == 5)
                target = point6.position;
            if (pointNumber == 6)
                target = point7.position;
            if (pointNumber == 7)
                target = point8.position;

            transform.LookAt(target);
       }
    }

    private void FixedUpdate() 
    { 
    
    }

    private void OnCollisionEnter (Collision collision)
    {
        
        if (collision.body as Rigidbody)
        {
            Vector3 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * power, ForceMode.VelocityChange);
        }
    }
}
