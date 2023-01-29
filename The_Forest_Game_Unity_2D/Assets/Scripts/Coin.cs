using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject MainCounter;
    public int value;
    private CoinCounter Counter;

    public void Start()
    {
        Counter = MainCounter.GetComponent<CoinCounter>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Counter.CoinGrab(value);
            

            gameObject.SetActive(false);
        }
    }
}

