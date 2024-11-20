using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyUnit;
    [SerializeField] private List<GameObject> _spawnPoint = new List<GameObject>();
    [SerializeField] private float _coolDown = 2f;
    [SerializeField] private bool _isActiveSpawner = true;
    [SerializeField] private bool Forward = false;
    [SerializeField] private bool Back = false;
    [SerializeField] private bool Left = false;
    [SerializeField] private bool Right = false;
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
        if (Forward == true & Right == false & Back == false & Left == false)
        {
            _pointDirection = Vector3.forward;
        }
        else if(Forward == false & Right == true & Back == false & Left == false)
        {
            _pointDirection = Vector3.right;
        }
        else if(Forward == false & Right == false & Back == true & Left == false) 
        {
            _pointDirection = Vector3.back;
        }
        else if(Forward == false & Right == false & Back == false & Left == true)
        {
            _pointDirection = Vector3.left;
        }
    }

    //public void SetDirection(string direction)
    //{
    //    switch (direction)
    //    {
    //        case FORWARD:
    //            _pointDirection = Vector3.forward;
    //            break;

    //        case DOWN:
    //            _pointDirection = Vector3.down;
    //            break;

    //        case BACK:
    //            _pointDirection = Vector3.back;
    //            break;

    //        case LEFT:
    //            _pointDirection = Vector3.left;
    //            break;

    //        default:
    //            Console.WriteLine("Ошибка нет такого направоения");
    //            break;
    //    }
    //}

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
