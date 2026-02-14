using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : GameObject
{
    private TargetSystem targetSystem;
    
    private EnemyMovement _movement;
    private float expAmount = 60f;
    
    public Action<Enemy,float> OnDead;
    
    public bool IsBoss {get; private set;}

    public void Init(bool isBoss)
    {
        IsBoss = isBoss;
    }

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

    public void SetTargetSystem(TargetSystem _targetSystem)
    {
        targetSystem = _targetSystem;
    }

    private void OnEnable()
    {
        _hp.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (targetSystem == null) return;
        targetSystem.Unregister(this);
        _hp.OnDeath -= HandleDeath; // 파괴되면 어차피 사라지지만 일단 그냥 
    }

    private void HandleDeath()
    {
        OnDead?.Invoke(this,expAmount);
        
        Destroy(gameObject);
    }
}