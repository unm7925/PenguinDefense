
using System;
using System.Transactions;
using UnityEngine;

public class Player : Character
{
    
    private MP _mp;
    private EXPSystem expSystem;
    
    
    //[SerializeField] private WeaponData;

    private void Awake()
    {
        
        expSystem = GetComponent<EXPSystem>();
        _mp = GetComponent<MP>();
    }

    private void OnEnable()
    {
        expSystem.Init();
    }


    // Update is called once per frame
    
}
