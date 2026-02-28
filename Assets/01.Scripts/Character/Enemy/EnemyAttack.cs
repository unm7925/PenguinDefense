using System;
using System.Collections;
using UnityEngine;
public class EnemyAttack:MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private float cooldown;
    [SerializeField] private float attackSpeed;
    
    [SerializeField] private GameObject projectile;

    private Transform target;
    
    public float AttackRange => attackRange;

    public event Action OnInRagne;

    public void Init(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        float distance = transform.position.y - target.position.y;

        if (distance <= attackRange) 
        {
            OnInRagne?.Invoke();
        }
    }

    public void AttackProjectile()
    {
        StartCoroutine(CreateProjectile());
    }
    private IEnumerator CreateProjectile()
    {
        GameObject projectiles = Instantiate(projectile, transform);
        Rigidbody2D rb2d = projectiles.GetComponent<Rigidbody2D>();
        rb2d.linearVelocityY = -attackSpeed;
        yield return new WaitForSeconds(cooldown);
    }

}

