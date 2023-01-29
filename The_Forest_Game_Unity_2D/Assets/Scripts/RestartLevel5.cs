using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel5 : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float health;
    private float timer = 2;

    void Update()
    {
        health = player.GetComponent<Health>().currentHealth;

        if(health <= 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
