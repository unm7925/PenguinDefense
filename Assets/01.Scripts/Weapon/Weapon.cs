using System;
using UnityEngine;
public class Weapon:MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] private int damage;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HP>().TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
