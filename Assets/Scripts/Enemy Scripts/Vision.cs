using UnityEngine;

public class Vision : MonoBehaviour
{
    EnemyAI enemy;

    void Awake()
    {
        enemy = GetComponent<EnemyAI>();
        PlayerLocator.GetPosition();
    }

    public bool CanSeePlayer()
    {
        if (PlayerLocator.Player == null)
            return false;
        PlayerLocator.GetPosition();
        Vector3 origin = transform.position;

        Vector3 direction =
            PlayerLocator.Player.position - origin;

        // Range check
        if (direction.magnitude > enemy.profile.visionRange)
            return false;

        // Angle check
        float angle =
            Vector3.Angle(transform.forward, direction);

        if (angle > enemy.profile.visionAngle * 0.5f)
            return false;

        // Line of sight check
        RaycastHit hit;

        if (Physics.Raycast(
            origin,
            direction.normalized,
            out hit,
            enemy.profile.visionRange))
        {
            if (hit.transform == PlayerLocator.Player)
                return true;
        }

        return false;
    }
}