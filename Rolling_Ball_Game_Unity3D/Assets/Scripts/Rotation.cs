using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int speed;

    void FixedUpdate()
    {
        transform.Rotate(0, speed, 0);
    }
}
