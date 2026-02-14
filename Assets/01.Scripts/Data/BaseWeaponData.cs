using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class BaseWeaponData : ScriptableObject
{
    public GameObject weaponPrefab;
    public string waeponName;
    public float damage;
    public float searchRange;
    public float baseCooldown;
    
    public ProjectileModule projectile;
    public BounceModule bounce;
    public PierceModule pierce;
    public AoEModule aoe;
}
