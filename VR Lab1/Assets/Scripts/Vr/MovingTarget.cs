using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField] private GameObject _targetStart;
    [SerializeField] private GameObject _targetEnd;
    [SerializeField] private float _speed;
    private bool _isFacingEnd;

    // Start is called before the first frame update
    void Start()
    {
        if (_targetStart == null || _targetEnd == null) { return; }
        transform.position = _targetStart.transform.position;
        _targetStart.SetActive(false);
        _targetEnd.SetActive(false);
        _isFacingEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetStart == null || _targetEnd == null) { return; }

        if (_isFacingEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetEnd.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetStart.transform.position, _speed * Time.deltaTime);
        }

        if (transform.position == _targetStart.transform.position || transform.position == _targetEnd.transform.position)
        {
            _isFacingEnd = !_isFacingEnd;
        }
    }
}
