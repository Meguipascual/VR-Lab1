using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Targets", menuName = "ScriptableObjects/Targets", order = 1)]
public class TargetWaveScriptable : ScriptableObject
{
    [SerializeField] private List<Vector3> _targetsPosition;
    [SerializeField] private List<Vector3> _movingTargetStart;
    [SerializeField] private List<Vector3> _movingTargetEnd;
    public int Stage { get; set; }
}
