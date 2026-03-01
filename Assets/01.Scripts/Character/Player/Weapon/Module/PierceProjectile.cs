using System;
using UnityEngine;
public class PierceProjectile:MonoBehaviour,IWeaponSetup
{
    private Projectile projectile;
    private int pierceAmount;
    public void Init(WeaponInstance weaponInstance)
    {
        pierceAmount = weaponInstance.PierceCount;
    }

    public void OnHit()
    {
        if (pierceAmount <= 0) 
        {
            Destroy(gameObject);    
        }
        else 
        {
            pierceAmount--;
        }
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

