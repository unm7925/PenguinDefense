using System;
using UnityEngine;
public class BounceProjectile:MonoBehaviour,IWeaponSetup
{
    private Projectile projectile;
    private Rigidbody2D rb2d;
    private int bounceAmount;
    private float speed;

    private Vector2 lastVelocity;
    
    public void Init(WeaponInstance weaponInstance)
    {
        bounceAmount = weaponInstance.BounceCount;
        speed = weaponInstance.Speed;
    }

    public void OnHit()
    {
    }

    private void Update()
    {
        lastVelocity = rb2d.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 normal = other.contacts[0].normal.normalized;
        Vector2 direction = Vector2.Reflect(lastVelocity.normalized, normal);
        Debug.Log(other.contacts[0].point);
        
        rb2d.linearVelocity = direction * speed;
        bounceAmount--;

        if (bounceAmount < 0) 
        {
            Destroy(gameObject);
        }
    }

    public void Awake()
    {
        projectile = GetComponent<Projectile>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        projectile.OnHit += OnHit;
    }
    private void OnDisable()
    {
        projectile.OnHit -= OnHit;
    }
}

