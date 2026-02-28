using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    
    
    
    private EnemyStateMachine stateMachine;

    private EnemyIdleState idleState;
    private EnemyMoveState moveState;
    private EnemyAttackState attackState;

    private EnemyAttack enemyAttack;
    
    private Transform target;
    
    private TargetSystem targetSystem;
    
    private EnemyMovement enemyMovement;
    
    private float expAmount;
    
    public Action<Enemy,float> OnDead;
    
    private HP hp;
    public bool IsBoss {get; private set;}

    public EnemyMovement EnemyMovement => enemyMovement;

    public EnemyAttack EnemyAttack => enemyAttack;

    public void Init(bool _isBoss, Transform _transform, TargetSystem _targetSystem)
    {
        IsBoss = _isBoss;
        target = _transform;
        targetSystem = _targetSystem;
    }

    protected void Awake()
    {
        hp = GetComponent<HP>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
        
       
        
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState();
        moveState = new EnemyMoveState();
        attackState = new EnemyAttackState();
    }

    void Start()
    {
        SetData(enemyData);
        
        idleState.Init(this,stateMachine);
        moveState.Init(this,stateMachine);
        attackState.Init(this,stateMachine);

        stateMachine.ChangeState(moveState);

        enemyAttack.OnInRagne += MoveToAttack;
    }
    // [SerializeField] private EnemyData _enemyData;

    private void Update()
    {
        stateMachine.Update();
    }

    private void MoveToAttack()
    {
        stateMachine.ChangeState(attackState);
    }


    private void OnEnable()
    {
        hp.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (targetSystem == null) return;
        targetSystem.Unregister(this);
        hp.OnDeath -= HandleDeath; // 파괴되면 어차피 사라지지만 일단 그냥 
        enemyAttack.OnInRagne -= MoveToAttack;
    }

    private void HandleDeath()
    {
        OnDead?.Invoke(this, expAmount);

        Destroy(gameObject);
    }

    private void SetData(EnemyData data)
    {
        hp.Init(enemyData.maxHP);
        enemyMovement.Init(enemyData.speed);
        enemyAttack.Init(target,enemyData.damage,enemyData.attackRange,enemyData.cooldown,enemyData.projectile,enemyData.projectileSpeed);
        expAmount = data.expAmount;
    }
}