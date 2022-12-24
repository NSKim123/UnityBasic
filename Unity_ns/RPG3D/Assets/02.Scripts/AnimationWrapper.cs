using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationWrapper : MonoBehaviour
{
    public bool isPreviousStateFinished { get; }
    public bool isPreviousMachineFinished { get; }
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }
}
