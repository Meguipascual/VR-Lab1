using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] rigidbodies;
    public Rigidbody mainRigidBody;

    void Start()
    {
        SetRagdoll(false);
    }

    public void SetRagdoll(bool active)
    {
        animator.enabled = !active;
        mainRigidBody.isKinematic = active;

        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !active;
        }
    }
}
