using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyState : AIState
{
    Vector3 patrolPoint;

    public NormalEnemyState(EnemyAI enemy)
        : base(enemy)
    {
    }

    public override void Enter()
    {
        Debug.Log("First random point");
        MoveToRandomPoint();
    }

    public override void UpdateState()
    {
        // ALWAYS use the Vision component once (no GetComponent spam)
        Vision vision = enemy.GetComponent<Vision>();

        if (vision != null && vision.CanSeePlayer())
        {
            Debug.Log("Can see player)");
            enemy.target = PlayerLocator.Player;

            enemy.ChangeState(new ChaseState(enemy));
            return;
        }

        if (!enemy.agent.pathPending &&
            enemy.agent.hasPath &&
            enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
        {
            Debug.Log("Pathfinding new point");
            MoveToRandomPoint();
        }
    }

    void MoveToRandomPoint()
    {
        Vector3 origin = enemy.transform.position;

        Vector2 randomCircle = Random.insideUnitCircle * 8f;

        Vector3 randomPoint = new Vector3(
            origin.x + randomCircle.x,
            origin.y,
            origin.z + randomCircle.y
        );
        Debug.Log("Random circle position is: " + randomPoint);

        if (Vector3.Distance(origin, randomPoint) < 3f)
        {
            MoveToRandomPoint();
            return;
        }

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 8f, NavMesh.AllAreas))
        {
            patrolPoint = hit.position;
            enemy.agent.SetDestination(patrolPoint);
        }
        Debug.Log("Moved to new random position");
    }
}