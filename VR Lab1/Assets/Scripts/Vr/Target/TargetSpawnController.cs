using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _movingTarget;
    [SerializeField] private List<Vector3> _targetPlacement;
    [SerializeField] private List<Vector3> _movingTargetStart;
    [SerializeField] private List<Vector3> _movingTargetEnd;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateTargets();
        InstantiateMovingTargets();
    }

    private void InstantiateTargets()
    {
        for (int i = 0; i < _targetPlacement.Count; i++)
        {
            Instantiate(_target, _targetPlacement[i], _target.transform.rotation);
        }
    }
    private void InstantiateMovingTargets()
    {
        for (int i = 0; i < _movingTargetStart.Count; i++)
        {
            var target = Instantiate(_movingTarget, new Vector3(0,0,0), _movingTarget.transform.rotation);
            var targetGameobjects = target.GetComponentsInChildren<Transform>(true);
            for (int j = 0; j < targetGameobjects.Length; j++) 
            {
                if (targetGameobjects[j].tag == Tags.TargetStart)
                {
                    targetGameobjects[j].transform.position = _movingTargetStart[i];
                }
                else if (targetGameobjects[j].tag == Tags.TargetEnd)
                {
                    targetGameobjects[j].transform.position = _movingTargetEnd[i];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
