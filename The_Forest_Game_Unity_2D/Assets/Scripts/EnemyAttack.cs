using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackDuration;
    [SerializeField] private float attackTiming;
    [SerializeField] private GameObject victoryMessage;

    private float timeBeforeAttackEnd;
    private bool attackIsHappening = false;
    private float attackTimer;
    private Animator anim;

    private Health health;

    private void Awake()
    {
        timeBeforeAttackEnd = attackDuration;
        anim = GetComponent<Animator>();
        attackTimer = attackTiming;
        health = GetComponent<Health>();
    }

    private void Attack()
    {
        attackCollider.SetActive(true);
        attackIsHappening = true;
        anim.SetTrigger("Attack");
    }

    private void FixedUpdate()
    {
        if(attackIsHappening)
        {
            timeBeforeAttackEnd -= Time.deltaTime;

            if(timeBeforeAttackEnd <= 0)
            {
                timeBeforeAttackEnd = attackDuration;
                attackCollider.SetActive(false);
                attackIsHappening = false;
            }
        }
    }

    private void Update()
    {
        if (health.isAlive)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackTiming;
            }
        }
        else
            victoryMessage.SetActive(true);
    }
}
