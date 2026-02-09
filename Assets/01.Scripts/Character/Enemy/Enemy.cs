using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    private EnemyMovement _movement;
    private float expAmount = 60f;
    
    public Action<float> OnDead;

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

    private void OnEnable()
    {
        GameManager.Instance.TargetSystem.Register(this);
        _hp.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        GameManager.Instance.TargetSystem.Unregister(this);
        _hp.OnDeath -= HandleDeath; // 파괴되면 어차피 사라지지만 일단 그냥 
    }

    private void HandleDeath()
    {
        OnDead?.Invoke(expAmount);
        
        Destroy(gameObject);
    }
}