using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFormation", menuName = "Formations/FormationData")]
public class FormationData : ScriptableObject
{
    [Tooltip("Name of the formation for reference")] 
    public string formationName;

    [Tooltip("Relative positions of each slot in the formation")] 
    public List<Vector3> relativePositions = new List<Vector3>();
}
