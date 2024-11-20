using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyUnit;
    [SerializeField] private List<GameObject> _spawnPoint = new List<GameObject>();
    [SerializeField] private float _coolDown = 2f;
    [SerializeField] private bool _isActiveSpawner = true;
    [SerializeField] private bool _forward = false;
    [SerializeField] private bool _back = false;
    [SerializeField] private bool _left = false;
    [SerializeField] private bool _right = false;
    private Vector3 _pointDirection;

    private void Start()
    {
        StartCoroutine(Create());
    }

    public void CreateEnemy()
    {
        int valueSpawnPointCount = _spawnPoint.Count;
        System.Random random = new System.Random();
        int numberPointSpawn = random.Next(valueSpawnPointCount);
        SetDirectionEnemy();
        Instantiate(_enemyUnit, _spawnPoint[numberPointSpawn].transform.position, Quaternion.identity).GetComponent<Enemy>().SetDirection(_pointDirection);
    }

    public void SetDirectionEnemy()
    {
        if (_forward == true & _right == false & _back == false & _left == false)
        {
            _pointDirection = Vector3.forward;
        }
        else if(_forward == false & _right == true & _back == false & _left == false)
        {
            _pointDirection = Vector3.right;
        }
        else if(_forward == false & _right == false & _back == true & _left == false) 
        {
            _pointDirection = Vector3.back;
        }
        else if(_forward == false & _right == false & _back == false & _left == true)
        {
            _pointDirection = Vector3.left;
        }
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
