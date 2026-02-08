using System;
using UnityEngine;

public class EnemyMovement:MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    public void Init() // <- float _speed; 
    { 

    }
    
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb2D.linearVelocityY = -speed  * Time.fixedDeltaTime;
    }
}
