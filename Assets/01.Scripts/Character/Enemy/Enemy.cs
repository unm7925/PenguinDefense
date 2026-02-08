using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private EnemyMovement _movement;
    

    private void Awake()
    {
        base.Awake();
        _movement = GetComponent<EnemyMovement>();
    }

    void Start()
    {
        _hp.Init();
        _movement.Init();
    }
    // [SerializeField] private EnemyData _enemyData;


}