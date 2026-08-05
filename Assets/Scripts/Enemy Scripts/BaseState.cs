public abstract class AIState
{
    protected EnemyAI enemy;
    public AIState(EnemyAI enemy)
    {
        this.enemy = enemy;
    }

    public virtual void Enter(){}

    public virtual void UpdateState(){}

    public virtual void Exit(){}
}