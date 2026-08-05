using UnityEngine;

public class ChaseState : AIState
{
    public ChaseState(EnemyAI enemy)
        : base(enemy) { }

    public override void Enter()
    {
        enemy.target = PlayerLocator.Player;
    }

    public override void UpdateState()
    {
        if (enemy.target == null)
            return;

        enemy.agent.SetDestination(
            enemy.target.position
        );


        float distance =
            Vector3.Distance(
                enemy.transform.position,
                enemy.target.position
            );


        if (distance <= enemy.profile.attackRange)
        {
            enemy.ChangeState(
                new AttackState(enemy)
            );
        }


        if (!enemy.GetComponent<Vision>().CanSeePlayer())
        {
            enemy.ChangeState(
                new SearchState(
                    enemy,
                    enemy.target.position
                )
            );
        }
    }
}