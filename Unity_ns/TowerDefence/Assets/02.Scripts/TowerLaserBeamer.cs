using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLaserBeamer : Tower
{
    [SerializeField] private LineRenderer _beam;
    [SerializeField] private ParticleSystem _laserHitEffect;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _damage;
    private int _damageStep;    
    

    public int DamageStep
    {
        get
        {
            return _damageStep;
        }
        set 
        {
            _damageStep = value;
            _beam.startWidth = 0.05f * (1 + value);
            _beam.endWidth = 0.05f * (1 + value);
            _laserHitEffect.transform.localScale = Vector3.one * (1 + value * 0.2f);
        }
    }
    [SerializeField] private float _damageChargeTime;
    [SerializeField] private float _damageGain;
    [SerializeField] private float _damagePeriod = 0.2f;
    private float _damageTimer;
    private float _chargeTimer;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Attack();
    }

    private void Attack()
    {
        if(Target == null)
        {
            if(_beam.enabled)
                _beam.enabled= false;

            if(_laserHitEffect.isPlaying)
                _laserHitEffect.Stop();

            if(DamageStep > 0)
                DamageStep = 0;

            if (_damageTimer > 0)
                _damageTimer = 0;
        }
        else
        {
            _beam.SetPosition(0, _firePoint.position);
            _beam.SetPosition(1, Target.position);

            if(_beam.enabled == false)
                _beam.enabled = true;

            if(_laserHitEffect.isStopped)
                _laserHitEffect.Play();

            if(Physics.Raycast(_firePoint.position, (Target.position - _firePoint.position).normalized,
                            out RaycastHit hit,
                            Vector3.Distance(Target.position, _firePoint.position), 
                            TargetLayer))
            {
                _laserHitEffect.transform.position = hit.point;
                _laserHitEffect.transform.LookAt(_firePoint);
            }

            if(_chargeTimer <= 0)
            {
                if(_damageStep <2)
                {
                    DamageStep++;
                    _chargeTimer = _damageChargeTime;

                }
                else
                {
                    _chargeTimer -= Time.fixedDeltaTime;
                }
            }


            if (_damageTimer <= 0)
            {

                if (Target.TryGetComponent(out Enemy enemy))
                {
                    enemy.Hurt((int)(_damage * (1 + DamageStep) * _damageGain));
                    _damageTimer = _damagePeriod;
                }
            }
            else
            {
                _damageTimer -= Time.fixedDeltaTime;
            }
        }
    }
}
