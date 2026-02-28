using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData:ScriptableObject
{
    [Header("Status")] 
    public int maxHP;
    public float speed;
    public int damage;
    public float attackRange;
    public float cooldown;
    
    [Header("Projectile")]
    public GameObject projectile;
    public float projectileSpeed;
    
    [Header("Reward")]
    public float expAmount;
}

