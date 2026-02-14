using System;
using UnityEngine;
public class Weapon:MonoBehaviour
{
    
    [SerializeField] protected BaseWeaponData data;
    private int level;
    private float cooldownTimer;
    private int maxLevel = 10;

    
    private TargetSystem targetSystem;
    private Transform player;
    
    public void Init(BaseWeaponData _data,Transform _playerTransform, TargetSystem _targetSystem)
    {
        data =  _data;
        level = 1;
        cooldownTimer = 0;
        
        player = _playerTransform;
        targetSystem = _targetSystem;
    }

    public void Tick(float deltaTime)
    {
        cooldownTimer += deltaTime;

        if (cooldownTimer >= data.baseCooldown) 
        {
            Attack(player, targetSystem);
        }
    }
    protected virtual void Attack(Transform _transform, TargetSystem _targetSystem)
    {
        
    }

    public BaseWeaponData GetWeaponData()
    {
        return data;
    }
    
    public void LevelUp()
    {
        if (IsMaxLevel()) return;
        level++;
        // 스탯 아직 생각한 테이블 없음.
        cooldownTimer = 0;
    }

    private bool IsMaxLevel()
    {
        if (level >= maxLevel) 
        {
            return true;
        }
        return false;
    }
}
