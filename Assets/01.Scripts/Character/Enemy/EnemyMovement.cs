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

    public void Init(float _speed,float _speedMultiplier =1)
    {
        speed = -(_speed * _speedMultiplier);
    }

    public void Move()
    {
        rb2D.linearVelocityY = speed  * Time.deltaTime;
    }

    public void Stop()
    {
        rb2D.linearVelocityY = 0;
    }
}
