
using System;
using System.Transactions;
using UnityEngine;

public class Player : GameObject
{
    
    private MP _mp;
    private EXPSystem expSystem;
    
    [SerializeField] private WeaponContainer weaponContainer;
    [SerializeField] private BaseWeaponData data;
    
    
    //[SerializeField] private WeaponData;

    private void Awake()
    {
        
        expSystem = GetComponent<EXPSystem>();
        _mp = GetComponent<MP>();
    }
    
    private void Start()
    {
        weaponContainer.AddWeapon(data);
    }

    private void OnEnable()
    {
        expSystem.Init();
    }


    // Update is called once per frame
    
}
