using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private int _life;
    public int Life
    {
        get 
        { 
            return _life; 
        }
        set
        {
            if(value >= 0)
            {
                _life = value;
                OnLifeChanged?.Invoke(value);  //? null üũ ������
            }            
        }
    }
    public event Action<int> OnLifeChanged;

    private int _money;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            OnMoneyChanged?.Invoke(value);
        }
    }
    public event Action<int> OnMoneyChanged;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(E_init());
    }

    IEnumerator E_init()
    {
        yield return new WaitUntil(() => GameManager.Instance != null &&
                                         GameManager.Instance.IsGameStarted);

        Life = GameManager.Instance.Data.LifeInit;
        Money = GameManager.Instance.Data.MoneyInit;
    }
}
