using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed,
                           timeToRevert;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rbody;
    private const float IDLE_STATE = 0,
                        RUN_STATE = 1,
                        REVERT_STATE = 2,
                        DAMAGED_STATE = 3,
                        ATTACK_STATE = 4;
    private float currentState,
                  currentTimeToRevert;
    private Health health;
    [SerializeField] float stunnedTime;
    private float stunnedTimer;
    private Vector3 scale;
    private float attackDuration = 0.4f,
                  timeBeforeAttackEnd;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private AudioSource Huh;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        currentTimeToRevert = 0;
        currentState = RUN_STATE;
        health = GetComponent<Health>();
        stunnedTimer = stunnedTime;
        scale = GetComponent<Transform>().localScale;
        timeBeforeAttackEnd = attackDuration;
    }

    void Update()
    {
        if (health.isAlive)
        { 
            if (currentTimeToRevert >= timeToRevert)
            {
                currentTimeToRevert = 0;
                currentState = REVERT_STATE;
            }

            if (stunnedTimer <= 0)
            {
                currentState = ATTACK_STATE;
                stunnedTimer = stunnedTime;
                attackCollider.SetActive(true);
                anim.SetTrigger("Attack");
                Huh.Play();
            }

            if (timeBeforeAttackEnd <= 0)
            {
                timeBeforeAttackEnd = attackDuration;
                attackCollider.SetActive(false);
                currentState = IDLE_STATE;
            }

            switch (currentState)
            {
                case IDLE_STATE:
                    currentTimeToRevert += Time.deltaTime;
                    anim.SetTrigger("Stop");
                    break;

                case RUN_STATE:
                    rbody.velocity = Vector2.left * speed;
                    anim.SetTrigger("Run");
                    break;

                case REVERT_STATE:
                    scale.x *= -1;
                    GetComponent<Transform>().localScale = scale;
                    speed *= -1;
                    currentState = RUN_STATE;
                    break;

                case DAMAGED_STATE:
                    stunnedTimer -= Time.deltaTime;                   
                    break;

                case ATTACK_STATE:                  
                    timeBeforeAttackEnd -= Time.deltaTime;                  
                    break;
            }
        }
        else
        {
            anim.SetTrigger("Death");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stopper"))
            currentState = IDLE_STATE;

        if (collision.gameObject.CompareTag("Player"))
        {
            currentState = DAMAGED_STATE;
            Huh.Play();
        }
    }

    public void GetHit()
    {
        currentState = DAMAGED_STATE;
        anim.SetTrigger("Hit");
    }
}
