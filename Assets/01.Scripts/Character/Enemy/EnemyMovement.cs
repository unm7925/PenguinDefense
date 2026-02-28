using System;
using UnityEngine;

public class EnemyMovement:MonoBehaviour
{
    private float speed;

    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    public void Init(float _speed)
    {
        speed = -_speed;
    }

    public void Move()
    {
        rb2D.linearVelocityY = speed  * Time.fixedDeltaTime;
    }

    public void Stop()
    {
        rb2D.linearVelocityY = 0;
    }
}
