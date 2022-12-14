using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            _hpBar.value = _hp / _hpMax;

            if (_hp <= 0)
            {

                GameObject effect = Instantiate(_destroyEffect.gameObject, transform.position, Quaternion.identity);
                Destroy(effect, _destroyEffect.main.duration);
                Destroy(gameObject);
            }
        }
    }

    public float score;
    
    [SerializeField] private float _hpMax;
    [SerializeField] private Slider _hpBar;

    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _targetLayer;

    private void Awake()
    {
        Hp = _hpMax;
    }

    private void FixedUpdate()
    {
        Vector3 deltaMove = Vector3.back * _moveSpeed*Time.deltaTime;
        transform.Translate(deltaMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(1<<other.gameObject.layer == _targetLayer)
        {
            
            if (other.TryGetComponent(out Player player))
            {
                Debug.Log("Damaged");
                player.Hp -= _damage;
            }
          
            Destroy(gameObject);
            
        }
    }
}
