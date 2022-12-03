using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected private bool IsGuided;
    protected float Speed;
    protected int Damage;
    protected LayerMask TargetLayer;
    protected LayerMask TouchLayer;
    protected Transform Target;

    public void SetUp(bool isGuided, float speed, int damage, LayerMask targetLayer, Transform target)
    {
        IsGuided= isGuided;
        Speed= speed;
        Damage= damage;
        TargetLayer= targetLayer;
        Target = target;

        transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        Move();        
    }

    private void Move()
    {
        if(IsGuided)
            transform.LookAt(Target);

        transform.Translate(Vector3.forward*Speed*Time.fixedDeltaTime, Space.Self);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(1<<other.gameObject.layer == TargetLayer)
        {
            //todo -> damage to target
        }
        else if(1 << other.gameObject.layer == TouchLayer)
        {
            //todo -> destroy self
        }
    }
}
