using UnityEngine;

[CreateAssetMenu(fileName = "NewTroopData", menuName = "Squads/Troop Data")]
public class TroopData : ScriptableObject
{
    [Tooltip("Prefab used to spawn each unit of this troop")] public GameObject unitPrefab;
    [Tooltip("Number of units spawned for this troop")] public int unitCount = 5;
}
