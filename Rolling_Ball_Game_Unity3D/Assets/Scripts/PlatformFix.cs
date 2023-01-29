using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFix : MonoBehaviour
{
    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void OnTriggerStay(Collider collision)
    {       
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(transform);
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(null);
    }
}
