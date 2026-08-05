using UnityEngine;

public class SearchState : AIState
{
    Vector3 searchPosition;
    float timer = 5f;

    public SearchState(
        EnemyAI enemy,
        Vector3 position
    ) : base(enemy)
    {
        searchPosition = position;
    }

    public override void Enter()
    {
        enemy.agent.SetDestination(
            searchPosition
        );
    }

    public override void UpdateState()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            enemy.ChangeState(
                new PatrolState(enemy)
            );
        }

        if (enemy.GetComponent<Vision>()
            .CanSeePlayer())
        {
            enemy.ChangeState(
                new ChaseState(enemy)
            );
        }
    }
}