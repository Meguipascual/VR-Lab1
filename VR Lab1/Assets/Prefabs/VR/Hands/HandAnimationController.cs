using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    private Animator _animator;
    private bool _isNull = true;
    private bool _isFirstCall = true;
    // Start is called before the first frame update
    private void TrySearch()
    {
        _isFirstCall = false;
        _animator = GetComponentInChildren<Animator>();
        if (_animator != null)
        {
            _isNull = false;
        }
        else
        {
            Debug.Log($"Animator is Null");
        } 
    }

    public void PlayPulseThumb() 
    {
        
        if (_isNull && _isFirstCall) 
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("PulseThumb");
        }
    }

    public void PlayReleaseThumb()
    {
        if (_isNull && _isFirstCall)
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("ReleaseThumb");
        }
    }

    public void PlayPulseIndex()
    {
        if (_isNull && _isFirstCall)
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("PulseIndex");
        }
    }

    public void PlayReleaseIndex()
    {
        if (_isNull && _isFirstCall)
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("ReleaseIndex");
        }
    }

    public void PlayPulseOthers()
    {
        if (_isNull && _isFirstCall)
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("PulseLower");
        }
    }

    public void PlayReleaseOthers()
    {
        if (_isNull && _isFirstCall)
        {
            TrySearch();
        }

        if (_animator.isActiveAndEnabled)
        {
            _animator.Play("ReleaseLower");
        }
    }
}
