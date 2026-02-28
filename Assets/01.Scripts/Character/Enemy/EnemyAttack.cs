using System;
using System.Collections;
using UnityEngine;
public class EnemyAttack:MonoBehaviour
{
    
    private float attackRange;
    private int damage;
    private float cooldown;
    private float attackSpeed;
    
    private GameObject projectile;
    
    public bool IsAttacking = false;
    
    private Transform target;
    
    //Hard
    private string targetTag = "Wall";

    public event Action OnInRagne;

    public void Init(Transform _target, int _damage,float _attackRange,float _cooldown, GameObject _projectile, float _attackSpeed)
    {
        target = _target;
        attackRange = _attackRange;
        damage = _damage;
        cooldown = _cooldown;
        projectile = _projectile;
        attackSpeed = _attackSpeed;
    }

    private void Update()
    {
        if (!IsAttacking && target != null) 
        {
            float distance = transform.position.y - target.position.y;

            if (distance <= attackRange) 
            {
                OnInRagne?.Invoke();
                IsAttacking = true;
            }
        }
    }

    public void AttackProjectile()
    {
        StartCoroutine(CreateProjectile());
    }
    private IEnumerator CreateProjectile()
    {
        while(true) 
        {
            GameObject projectiles = Instantiate(projectile, transform);
            Projectile projectileState = projectiles.GetComponent<Projectile>();
            projectileState.Init(damage, cooldown, targetTag);
            Rigidbody2D rb2d = projectiles.GetComponent<Rigidbody2D>();
            rb2d.linearVelocityY = -attackSpeed *Time.deltaTime;
            yield return new WaitForSeconds(cooldown);
        }
    }

}

