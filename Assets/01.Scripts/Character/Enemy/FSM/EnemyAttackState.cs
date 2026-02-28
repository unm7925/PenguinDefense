public class EnemyAttackState:EnemyState
{

    public override void Enter()
    {
        enemy.EnemyAttack.AttackProjectile();
    }
   
    public override void Update()
    {
        
    }
    
    public override void Exit()
    {
        enemy.EnemyAttack.StopAllCoroutines();
        enemy.EnemyAttack.IsAttacking = false;
    }
}
