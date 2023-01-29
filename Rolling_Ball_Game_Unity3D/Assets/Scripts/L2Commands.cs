using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Commands : MonoBehaviour
{
    public GameObject door_1;
    public GameObject panel;
    private bool i = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Open_1"))
        {
            StartCoroutine(timer_1());
        }
    }

    void Update()
    {
        if (i)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                
                door_1.SetActive(false);
                panel.SetActive(false);
            }
        }
    }

    IEnumerator timer_1()
    {
        yield return new WaitForSeconds(1);

        panel.SetActive(true);
        i = true;
    }
}
