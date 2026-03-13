using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAim : MonoBehaviour
{
    private Ray _aimRay;
    private RaycastHit _hit;
    private Vector3 _origin;
    private Vector3 _direction;
    private Color _colorNoHit;
    private Color _colorHit;
    [SerializeField] LayerMask _layerMask;
    [SerializeField]private float _detectionDistance;

    private void Start()
    {
        _detectionDistance = 50f;
        _colorNoHit = Color.green;
        _colorNoHit.a = 0.2f;
        _colorHit = Color.magenta;
        _colorHit.a = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        _origin = transform.position;
        _direction = transform.forward;
        _aimRay = new Ray(_origin, _direction);
       
        if (!Physics.Raycast(_aimRay, out _hit, _detectionDistance, _layerMask))
        {
            Debug.DrawLine(_origin, _hit.point, _colorNoHit);
        }
        else
        {
            Debug.DrawLine(_origin, _direction * _detectionDistance, _colorHit);
        }
    }
    public RaycastHit GetTarget()
    {
        return _hit;
    }
}
