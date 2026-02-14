using System.Collections.Generic;
using UnityEngine;
public class WeaponContainer : MonoBehaviour
{
    private List<WeaponInstance> ownedWeapons = new List<WeaponInstance>();
    [SerializeField] private TargetSystem targetSystem;
    [SerializeField] private Transform parent;

    public void AddWeapon(BaseWeaponData data)
    {
        // 이미 가진 무기인지 확인
        WeaponInstance existing = ownedWeapons.Find(w => w.data == data);
        if (existing != null)
        {
            existing.LevelUp();
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
            weapon.Tick(deltaTime,parent,targetSystem);  // 공격 처리
        }
    }
}
