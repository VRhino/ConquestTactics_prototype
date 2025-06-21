using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSquadLoadout", menuName = "Squads/Squad Loadout")]
public class SquadLoadout : ScriptableObject
{
    public List<TroopData> troops = new List<TroopData>();
}
