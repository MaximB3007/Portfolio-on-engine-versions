using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image img;
    [SerializeField] GameObject deathMessage;
    [SerializeField] AudioSource damageSound;

    public float currentHealth;
    public bool isAlive;
    private Animator anim;
    float timerToDisappear = 0.6f;
    public GameObject attackingCharecter;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        damageSound.Play();

        if (attackingCharecter.transform.position.x > gameObject.transform.position.x)
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        else
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);

        currentHealth -= damage;
        CheckIsAlive();
    }          

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
            anim.SetTrigger("Hit");

            if (gameObject.layer == 8)
                GetComponent<EnemyMovement>().GetHit();
        }
        else
        {
            isAlive = false;
            anim.SetTrigger("Death");
            deathMessage.SetActive(true);
        }
    }

    private void Update()
    {
        img.fillAmount = currentHealth / maxHealth;

        if (!isAlive)
        {
            timerToDisappear -= Time.deltaTime;

            if (timerToDisappear <= 0)
                gameObject.SetActive(false);
        }
    }
}
