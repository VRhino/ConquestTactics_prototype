using UnityEngine;

[CreateAssetMenu(fileName = "MovementSettings", menuName = "Player/Movement Settings")]
public class MovementSettings : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float lookSensitivity = 2f;
}
