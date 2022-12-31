using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Timeline;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    public enum Mode
    {
        Auto,
        Manual
    }
    private Mode _mode;
    public Mode mode
    {
        get 
        {
            return _mode; 
        }
        set 
        {
            if (_mode == value)
                return;

            _inertia = _rb.velocity;
            _mode = value; 
        }
    }
    private Vector3 _inertia;
    [Range(0.0f, 1.0f)]
    private float _drag = 0.1f;
    private float gain => Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
    private float _h => Input.GetAxis("Horizontal");
    private float _v => Input.GetAxis("Vertical");
    private float _multiplier = 0.5f;
    private Animator _animator;
    private Rigidbody _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        _animator.SetFloat("h", _h * _multiplier * gain);
        _animator.SetFloat("v", _v * _multiplier * gain);
    }

    private void FixedUpdate()
    {
        if(_mode== Mode.Manual)
        {
            transform.position += new Vector3(_inertia.x, 0.0f, _inertia.z) * Time.deltaTime;
            _inertia = Vector3.Lerp(_inertia, Vector3.zero, _drag * Time.deltaTime);
        }
    }
}
