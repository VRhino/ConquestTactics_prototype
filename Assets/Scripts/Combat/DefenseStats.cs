using UnityEngine;

[System.Serializable]
public class DefenseStats : MonoBehaviour
{
    [Range(0f, 1f)]
    public float slashingResistance = 0f;
    [Range(0f, 1f)]
    public float piercingResistance = 0f;
    [Range(0f, 1f)]
    public float bluntResistance = 0f;
}
