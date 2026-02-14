using System.Collections.Generic;
using UnityEngine;
public class WeaponContainer : MonoBehaviour
{
    private List<WeaponInstance> ownedWeapons = new List<WeaponInstance>();
    [SerializeField] private TargetSystem targetSystem;
    [SerializeField] private Transform playerTransform;

    public void AddWeapon(BaseWeaponData data)
    {
        // 이미 가진 무기인지 확인
        WeaponInstance existing = GetWeapon(data);
        if (existing != null) 
        {
            LevelUpWeapon(data);
        }
        else
        {
            // WeaponInstance는 MonoBehaviour 아님, 그냥 데이터 객체
            WeaponInstance newWeapon = new WeaponInstance(data);
            ownedWeapons.Add(newWeapon);
        }
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        foreach (var weapon in ownedWeapons)
        {
            weapon.Tick(deltaTime,playerTransform,targetSystem);  // 공격 처리
        }
    }
    
    private void LevelUpWeapon(BaseWeaponData _data)
    {
        WeaponInstance weapon = GetWeapon(_data);

        if (weapon != null)
        {
            weapon.LevelUp();
        }
    }

    private WeaponInstance GetWeapon(BaseWeaponData _data)
    {
        foreach (var weapon in ownedWeapons)
        {
            if (weapon.GetWeaponData() == _data)
            {
                return weapon;
            }
        }

        return null;
    }
    
    /*
        private void RemoveWeapon(BaseWeaponData _data)
        {

        }


         private bool HasWeapon(BaseWeaponData _data)
        {

        }
        */
}
