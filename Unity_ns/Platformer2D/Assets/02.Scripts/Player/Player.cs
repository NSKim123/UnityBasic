using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player Instance;

    public bool invinciable;
    private int _hp;
    
    public int Hp
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
            _hpBar.value = (float)_hp / _hpMax;
        }
    }
    [SerializeField] private Slider _hpBar;
    [SerializeField] private int _hpMax;
    private CapsuleCollider2D _col;
    private StateMachine _machine;
    [SerializeField] private LayerMask _enemyMask;
    
    public void Hurt(int damage)
    {
        if (invinciable)
            return;
            
        Hp -= damage;

        DamagePopUp.Create(transform.position + Vector3.up * _col.size.y / 2.0f, damage, 1 << gameObject.layer);

        if (_hp > 0)
            _machine.ChangeState(StateMachine.StateType.Hurt);
        else
            _machine.ChangeState(StateMachine.StateType.Die);
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        

        Hp = _hpMax;
        _machine = GetComponent<StateMachine>();
        _col = GetComponent<CapsuleCollider2D>();
        
    }

   
}
