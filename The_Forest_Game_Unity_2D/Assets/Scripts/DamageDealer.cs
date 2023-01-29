using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject attackingCharacter;

    private void Start()
    {
      damage = attackingCharacter.GetComponent<DamageScript>().attackStrength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable") || collision.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<Health>().attackingCharecter = attackingCharacter;
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
