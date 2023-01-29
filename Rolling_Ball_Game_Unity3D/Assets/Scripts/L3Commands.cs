using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Commands : MonoBehaviour
{
    public GameObject door_2;
    public GameObject drop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Open_3"))
        {
            StartCoroutine(timer_1());
        }

        if (other.CompareTag("Open_2"))
        {
            StartCoroutine(timer_2());
        }
    }

    IEnumerator timer_1()
    {
        yield return new WaitForSeconds(2);

        door_2.SetActive(false);
    }

    IEnumerator timer_2()
    {
        yield return new WaitForSeconds(2);

        drop.SetActive(false);
    }
}
