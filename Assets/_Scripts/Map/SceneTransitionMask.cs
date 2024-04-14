using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionMask : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartTransition()
    {
        animator.Play("Start");
    }

    public void EndTransition()
    {
        animator.Play("End");
    }
}
