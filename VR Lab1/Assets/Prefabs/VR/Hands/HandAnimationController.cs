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
        
        if (_isNull) 
        {
            TrySearch();
            return;
        }
        _animator.Play("PulseThumb");
    }

    public void PlayReleaseThumb()
    {
        if (_isNull)
        {
            TrySearch();
            return;
        }
        _animator.Play("ReleaseThumb");
    }
    public void PlayPulseIndex()
    {

        if (_isNull)
        {
            TrySearch();
            return;
        }
        _animator.Play("PulseIndex");
    }
    public void PlayReleaseIndex()
    {
        if (_isNull)
        {
            TrySearch();
            return;
        }
        _animator.Play("ReleaseIndex");
    }

    public void PlayPulseOthers()
    {

        if (_isNull)
        {
            TrySearch();
            return;
        }
        _animator.Play("PulseMid");
        _animator.Play("PulseRing");
        _animator.Play("PulsePinky");
    }

    public void PlayReleaseOthers()
    {
        if (_isNull)
        {
            TrySearch();
            return;
        }
        _animator.Play("ReleaseMid");
        _animator.Play("ReleaseRing");
        _animator.Play("ReleasePinky");
    }
}
