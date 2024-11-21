using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyUnit;
    [SerializeField] private List<GameObject> _spawnPoint= new List<GameObject>();
    [SerializeField] private float _coolDown= 2f;
    [SerializeField] private bool _isActiveSpawner= true;
    private Vector3 _pointDirection;
    private List<Vector3> _direction= new List<Vector3>()
    {
            Vector3.forward,
            Vector3.right,
            Vector3.back,
            Vector3.left
    };
    private int _randomDirection; 

    private void Start()
    {
        StartCoroutine(Create());
    }

    private void CreateEnemy()
    {
        int valueSpawnPointCount = _spawnPoint.Count;
        System.Random random = new System.Random();
        int numberPointSpawn = random.Next(valueSpawnPointCount);
        SetDirectionEnemy();
        Instantiate(_enemyUnit, _spawnPoint[numberPointSpawn].transform.position, Quaternion.identity).SetDirection(_pointDirection);
    }

    private void SetDirectionEnemy()
    {
        int minimumNumberList = 0;
        _randomDirection= Random.Range(minimumNumberList, _direction.Count);
        _pointDirection = _direction[_randomDirection];
    }

    private IEnumerator Create()
    {
        var waitForSeconds = new WaitForSeconds(_coolDown);

        while (_isActiveSpawner)
        {
            CreateEnemy();

            yield return waitForSeconds;
        }
    }
}
