using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
  private void OnTriggerEnter()
  {
        GetComponent<Rigidbody>().useGravity = false;
  }

  private void OnTriggerExit()
  {
        GetComponent<Rigidbody>().useGravity = true;
    }

}
