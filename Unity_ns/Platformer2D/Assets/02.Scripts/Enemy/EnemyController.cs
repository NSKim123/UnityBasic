using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Vector2 _knockbackForce = new Vector2(1.0f, 1.0f);
    public void KnockBack(int knockbackDirection)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(_knockbackForce.x * _knockbackForce.x, _knockbackForce.y),
                               ForceMode2D.Impulse);
    }
}
