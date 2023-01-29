using UnityEngine;
using UnityEngine.UI;

    public class CoinCounter : MonoBehaviour
    {
        public Text counter;
        public int coins;
        public AudioSource coinSound;
    

        private void Awake()
        {
            coins = 0;
        }

        public void CoinGrab(int x)
        {
            coins += x;
            coinSound.Play();
        }

        private void Update()
        {
            counter.text = coins.ToString();
        }
    }

