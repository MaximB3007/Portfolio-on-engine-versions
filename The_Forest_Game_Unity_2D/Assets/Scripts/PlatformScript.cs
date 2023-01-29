using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Rigidbody2D rbody;
    public bool currentDirection;
    public float speed;
    private Vector2 direction1;
    private Vector2 direction2;
    private Transform transform;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();     
        direction1 = new Vector2(1f, 0);
        direction2 = new Vector2(-1f, 0);
        transform = GetComponent<Transform>();
    }
  
    void FixedUpdate()
    {
        if (currentDirection)
        {
            rbody.velocity = direction1 * speed;              
        }
        else
        {
            rbody.velocity = direction2 * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
            currentDirection = !currentDirection;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(transform);
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(null);
    }
}
