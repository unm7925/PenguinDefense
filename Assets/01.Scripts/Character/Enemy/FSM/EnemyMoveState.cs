public class EnemyMoveState:EnemyState
{

    public override void Enter()
    {
        
    }
  
    public override void Update()
    {
        enemy.EnemyMovement.Move();
    }
    
    public override void Exit()
    {
        enemy.EnemyMovement.Stop();
    }
}

