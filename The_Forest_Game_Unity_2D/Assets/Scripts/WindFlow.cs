using UnityEngine;

public class WindFlow : MonoBehaviour
{
    [SerializeField] bool flowIsActive;
    [SerializeField] GameObject flow;
    [SerializeField] float activeTime,
                           inactiveTime;
    [SerializeField] private AudioSource windSound;

    private float activeTimer,
                  inactiveTimer;

    void Start()
    {
        activeTimer = activeTime;
        inactiveTimer = inactiveTime;
        windSound.Play();
    }

    void Update()
    {
        if(flowIsActive)
        {
            activeTimer -= Time.deltaTime;
            
            if (activeTimer <= 0)
            {
                flowIsActive = !flowIsActive;
                flow.SetActive(false);
                activeTimer = activeTime;
                windSound.Pause();
            }
        }
        else
        {
            inactiveTimer -= Time.deltaTime;


            if (inactiveTimer <= 0)
            {
                flowIsActive = !flowIsActive;
                flow.SetActive(true);
                inactiveTimer = inactiveTime;
                windSound.Play();
            }
        }
    }
}
