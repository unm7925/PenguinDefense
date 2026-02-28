public abstract class EnemyState:IState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;

    public void Init(Enemy _enemy, EnemyStateMachine _stateMachine)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
    }
    
    public abstract void Enter();
    
    public abstract void Update();
    
    public abstract void Exit();
}

