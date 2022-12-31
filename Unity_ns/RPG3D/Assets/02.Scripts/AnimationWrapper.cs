using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationWrapper : MonoBehaviour
{
    public bool isPreviousStateFinished => _monitorOnStateHashMem == _monitorOffStateHash;
    public bool isPreviousMachineFinished => _monitorOnMachineHashMem == _monitorOffMachineHash;

    private int _monitorOnStateHash;   //������ ���� ������ �ִϸ��̼� ������ �ؽ��ڵ�
    private int _monitorOnStateHashMem; // ������ ������ �ִϸ��̼� ������ �ؽ��ڵ�
    private int _monitorOffStateHash;   //������ ���� �ִϸ��̼� ������ �ؽ��ڵ�

    private int _monitorOnMachineHash;   //������ ���� ������ �ִϸ��̼� ����ӽ��� �ؽ��ڵ�
    private int _monitorOnMachineHashMem; // ������ ������ �ִϸ��̼� ����ӽ��� �ؽ��ڵ�
    private int _monitorOffMachineHash;   //������ ���� �ִϸ��̼� ����ӽ��� �ؽ��ڵ�

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator= GetComponent<Animator>();

        foreach(AnimatorStateMonitor monitor in _animator.GetBehaviours<AnimatorStateMonitor>())
        {
            monitor.OnEnter += (hash) =>
            {
                _monitorOnStateHashMem = _monitorOnStateHash;
                _monitorOnStateHash = hash;
            };

            monitor.OnExit += (hash) =>
            {
                _monitorOffStateHash = hash;
            };
        }

        foreach (AnimatorMachineMonitor monitor in _animator.GetBehaviours<AnimatorMachineMonitor>())
        {
            monitor.OnEnter += (hash) =>
            {
                _monitorOnMachineHashMem = _monitorOnMachineHash;
                _monitorOnMachineHash = hash;
            };

            monitor.OnExit += (hash) =>
            {
                _monitorOffMachineHash = hash;
            };
        }
    }

    public void SetBool(string clipName, bool value) => _animator.SetBool(clipName, value);
    public bool GetBool(string clipName) => _animator.GetBool(clipName);
    public void SetInt(string clipName, int value) => _animator.SetInteger(clipName, value);
    public int GetInt(string clipName) => _animator.GetInteger(clipName);
    public void SetFloat(string clipName, float value) => _animator.SetFloat(clipName, value);
    public void GetFloat(string clipName) => _animator.GetFloat(clipName);

    public float GetNormalizedTime() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
}
