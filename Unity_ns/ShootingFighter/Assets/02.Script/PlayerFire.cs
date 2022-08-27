using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;   //SerializeField : private 변수이지만 Inspector 창에 띄움

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bulletPrefab, _firePoint.position, _bulletPrefab.transform.rotation);
        }
    }
}
