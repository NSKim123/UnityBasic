using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Enemy : MonoBehaviour
{
    private float _hp;
    public float Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value < 0)
                value = 0;

            _hp = value;
            _hpSlider.value = value / _hpMax;

            if (_hp <= 0)
                Die();
        }
    }
    [SerializeField] private float _hpMax;
    [SerializeField] private Slider _hpSlider;

    public event Action OnDie;
    private float _speed;
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
    [SerializeField] private float _speedOrigin = 2.0f;

    public void Hurt(int damage)
    {
        Hp -= damage;
    }  
    


    public void Die()
    {
        OnDie?.Invoke();
    }

    private void Awake()
    {
        Hp = _hpMax;
        Speed = _speedOrigin;
    }
}
