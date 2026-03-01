using System;
using UnityEngine;

public class AoEProjectile : MonoBehaviour, IWeaponSetup
{
    private Projectile projectile;
    private float radious;
    private int damage;
    
    public void Init(WeaponInstance weaponInstance)
    {
        radious = weaponInstance.AOERadius;
        damage = weaponInstance.Damage;
    }
    public void OnHit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radious, LayerMask.GetMask("Enemy"));

        foreach(var hit in hits) 
        {
            hit.GetComponent<HP>().TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
    public void Awake()
    {
        projectile = GetComponent<Projectile>();
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

