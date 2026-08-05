using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public EnemyProfile profile;

    public Transform target;

    public NavMeshAgent agent;

    public AIState currentState;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = profile.moveSpeed;
    }

    void Start()
    {
        switch(profile.behaviour)
        {
            case AIBehaviour.Normal:
                ChangeState(new NormalEnemyState(this));
                break;

            case AIBehaviour.Stalker:
                ChangeState(new StalkerState(this));
                break;
        }
    }

    void Update()
    {
        currentState?.UpdateState();
    }

    public void ChangeState(AIState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }

public void HearNoise(Vector3 position, NoiseType type)
    {
        switch (type)
        {
            case NoiseType.Footstep:

                ChangeState(
                    new SearchState(this, position)
                );
                break;

            case NoiseType.Door:
                ChangeState(
                    new SearchState(this, position)
                );
                break;

            case NoiseType.Weapon:

                ChangeState(
                    new ChaseState(this)
                );
                break;

            case NoiseType.Explosion:

                ChangeState(
                    new SearchState(this, position)
                );
                break;
        }
    }
}