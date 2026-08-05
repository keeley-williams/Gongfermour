using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public class VisionDebug : MonoBehaviour
{
    public Transform visionOrigin; // <- IMPORTANT

    public Color visionColor = Color.yellow;
    public Color blockedColor = Color.red;
    public Color detectedColor = Color.green;

    EnemyAI enemy;

    void Awake()
    {
        enemy = GetComponent<EnemyAI>();

        // fallback so it never breaks
        if (visionOrigin == null)
            visionOrigin = transform;
    }

    void OnDrawGizmos()
    {
        if (enemy == null || enemy.profile == null)
            return;

        Vector3 origin = visionOrigin.position;
        Vector3 forward = visionOrigin.forward;

        float range = enemy.profile.visionRange;
        float angle = enemy.profile.visionAngle;

        Gizmos.color = visionColor;
        Gizmos.DrawWireSphere(origin, range);

        Vector3 leftDir = Quaternion.AngleAxis(-angle * 0.5f, Vector3.up) * forward;
        Vector3 rightDir = Quaternion.AngleAxis(angle * 0.5f, Vector3.up) * forward;

        Gizmos.DrawLine(origin, origin + leftDir * range);
        Gizmos.DrawLine(origin, origin + rightDir * range);

        Transform player = PlayerLocator.Player;
        if (player == null) return;

        Vector3 toPlayer = player.position - origin;

        float distance = toPlayer.magnitude;
        float angleToPlayer = Vector3.Angle(forward, toPlayer.normalized);

        bool detected =
            distance <= range &&
            angleToPlayer <= angle * 0.5f;

        Gizmos.color = detected ? detectedColor : blockedColor;

        Gizmos.DrawLine(origin, PlayerLocator.GetPosition() + Vector3.up * 1.5f);
    }
}