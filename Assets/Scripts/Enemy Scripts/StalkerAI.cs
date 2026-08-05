using Unity.VisualScripting;
using UnityEngine;

public class StalkerState : AIState
{
    float timer;
    public StalkerState(EnemyAI enemy)
    : base(enemy){}

    public override void Enter()
    {
        Debug.Log("Entered stalker state!");
        timer = 8;
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

        timer -= Time.deltaTime;

        if(timer <=0)
        {
            Vector2 randCirc = Random.insideUnitCircle * 10;
            Vector3 offset = new Vector3(
                randCirc.x,
                0,
                randCirc.y
            );

            enemy.agent.SetDestination(
            enemy.target.position + offset);

            timer = 8;
        }
    }
}