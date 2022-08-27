using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //지역변수 앞에 _를 붙이는 것이 관행인듯
    private float _h => Input.GetAxisRaw("Horizontal");
    private float _v => Input.GetAxisRaw("Vertical");
    private void FixedUpdate()
    {
        Vector3 directionVector = new Vector3(_h, 0, _v).normalized;
        Vector3 deltaMove = directionVector * _moveSpeed * Time.deltaTime;
        transform.Translate(deltaMove);
    }
}
