using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessStar : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    [SerializeField] private Animation _anim;
    public void Show()
    {
        _anim.Play();
    }
}
