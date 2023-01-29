using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AudioSource Huh;

    [Header("Attack settings")]
    [SerializeField] private GameObject attackCollider;
    private float attackDuration = 0.4f;

    private Rigidbody2D rbody;
    private float timeBeforeAttackEnd;
    private bool attackIsHappening = false;
    private Animator anim;
    private Health health;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        timeBeforeAttackEnd = attackDuration;
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        if (attackIsHappening)
        {
            timeBeforeAttackEnd -= Time.deltaTime;

            if (timeBeforeAttackEnd <= 0)
            {
                timeBeforeAttackEnd = attackDuration;
                attackCollider.SetActive(false);
                attackIsHappening = false;
            }
        }
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isGrounded)
        {
            anim.SetTrigger("Landed");

            if (isJumpButtonPressed)
                Jump();
        }
        else
        {
            anim.SetTrigger("Jump");
            
        }
        
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
            if(isGrounded)
                anim.SetTrigger("Run");
        }
        else
            if(isGrounded)
                anim.SetTrigger("Stop");
    }

    private void Jump()
    {      
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
        Huh.Play();
    }

    private void HorizontalMovement(float direction)
    {
        rbody.velocity = new Vector2(curve.Evaluate(direction), rbody.velocity.y);
        if (direction > 0)
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);          
        }
    }

    public void Attack()
    {
        if (isGrounded)
        {
            attackCollider.SetActive(true);
            attackIsHappening = true;
            anim.SetTrigger("Attack");
            Huh.Play();
        }
    }
}
