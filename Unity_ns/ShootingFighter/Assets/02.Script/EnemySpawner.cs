using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spanDelay= 0.5f;
    [SerializeField] private BoxCollider _spanBound;
    private float _timer;
    private Vector3 _spawnPos;
    private void Awake()
    {
        _timer = _spanDelay;
    }
    private void Update()
    {
        if (_timer < 0)
        {
            _spawnPos = new Vector3(transform.position.x + _spanBound.center.x + Random.Range(-_spanBound.size.x / 2.0f, _spanBound.size.x / 2.0f),
                transform.position.y + _spanBound.center.y + Random.Range(-_spanBound.size.y / 2.0f, _spanBound.size.y / 2.0f),
                transform.position.z + _spanBound.center.z);

            Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
            _timer = _spanDelay;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

}
