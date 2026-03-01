using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseWeaponData", menuName = "Scriptable Objects/WeaponData")]
public class BaseWeaponData : ScriptableObject
{
    public List<UpgradeOption> upgradeOptions;
    
    public GameObject weaponPrefab;
    public string waeponName;
    public int damage;
    public float searchRange;
    public float baseCooldown;
    
    public ProjectileModule projectile;
    public BounceModule bounce;
    public PierceModule pierce;
    public AoEModule aoe;
}
