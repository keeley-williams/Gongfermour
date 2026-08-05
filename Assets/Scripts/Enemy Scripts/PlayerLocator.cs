using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    public static Transform Player;
    public static Vector3 newPosition;

    //Need this offset as set up of player model is offset and effecting the vision system
    public static Vector3 positionOffset = new Vector3 (0, -15f, 0); 

    void Awake()
    {
        Player = transform;
        Debug.Log("Player position: " + Player.position);
    }

    public static Vector3 GetPosition()
    {
        newPosition = Player.position + positionOffset;
        Debug.Log("Offset position: " + newPosition);
        return newPosition;
    }
}
