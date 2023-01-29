using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject particles;
    public AudioSource grab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            particles.SetActive(true);
            grab.Play();
            MeshRenderer m = GetComponent<MeshRenderer>();
            m.enabled = false;
            StartCoroutine(timer_1());
        }

        IEnumerator timer_1()
        {
            yield return new WaitForSeconds(1);
            particles.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
