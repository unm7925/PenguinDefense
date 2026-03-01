using System.Collections.Generic;
using UnityEngine;
public class WeaponContainer : MonoBehaviour
{
    private List<WeaponInstance> ownedWeapons = new List<WeaponInstance>();
    [SerializeField] private TargetSystem targetSystem;
    [SerializeField] private Transform playerTransform;
    
    public List<WeaponInstance> OwnedWeapons => ownedWeapons;

    public void AddWeapon(BaseWeaponData data)
    {
        // 이미 가진 무기인지 확인

        WeaponInstance newWeapon = new WeaponInstance(data);
        ownedWeapons.Add(newWeapon);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        foreach (var weapon in ownedWeapons)
        {
            weapon.Tick(deltaTime,playerTransform,targetSystem);  // 공격 처리
        }
    }
    
    public void UpgradeWeapon(BaseWeaponData _data)
    {
        WeaponInstance weapon = GetWeapon(_data);

        if (weapon != null)
        {
            weapon.ApplyUpgrade();
        }
    }

    public WeaponInstance GetWeapon(BaseWeaponData _data)
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

    public List<WeaponInstance> GetUpgradeableWeapons()
    {
        List<WeaponInstance> upradeableWeapons = new List<WeaponInstance>();
        foreach (var weapon in ownedWeapons) 
        {
            if (!weapon.IsMaxLevel()) 
            {
                upradeableWeapons.Add(weapon);
            }
        }

        return upradeableWeapons;

    }
    
    /*
        private void RemoveWeapon(BaseWeaponData _data)
        {

        }
*/

        public bool HasWeapon(BaseWeaponData _data)
        {
            foreach (var weapon in ownedWeapons)
            {
                if (weapon.GetWeaponData() == _data)
                {
                    return true;
                }
            }

            return false;
        }
        
}
