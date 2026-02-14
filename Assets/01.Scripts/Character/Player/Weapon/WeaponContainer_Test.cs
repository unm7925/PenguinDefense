using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponContainer_Test: MonoBehaviour
{
        private List<Weapon> ownedWeapons;
        
        [SerializeField] private Transform parent;
        
        private void Update()
        {
                foreach (var weapon in ownedWeapons) 
                {
                        weapon.Tick(Time.deltaTime);
                }
        }

        public void AddWeapon(BaseWeaponData _data, Transform _playerTransform, TargetSystem _targetSystem)
        {
                Weapon weapon = GetWeapon(_data);

                if (weapon != null)
                {
                        LevelUpWeapon(_data);
                }
                else 
                {
                        //Weapon newWeapon = WeaponFactory.CreateWeapon(_data, _playerTransform, _targetSystem, parent);
                        //ownedWeapons.Add(newWeapon);
                }
        }
        
        /*
        private void RemoveWeapon(BaseWeaponData _data)
        {

        }


         private bool HasWeapon(BaseWeaponData _data)
        {

        }
        */

        private void LevelUpWeapon(BaseWeaponData _data)
        {
                Weapon weapon = GetWeapon(_data);

                if (weapon != null)
                {
                        weapon.LevelUp();
                }
        }

        private Weapon GetWeapon(BaseWeaponData _data)
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
        
        
}
