using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemysToSpawn;
    [SerializeField] private Transform[] _respawnPoint;
    
    private int _currentSpawn;

    [SerializeField] public float _amountToInstantiate;
    [SerializeField] private float _instantiateCount;
    [SerializeField] private float timeToInstantiate;
    [SerializeField] private float timeToStart;
    private void Start()
    {

        _currentSpawn = 0;
        _instantiateCount = 0;
        


    }
    private void Update()
    {
        while (_amountToInstantiate > _instantiateCount)
        {
            EnemySpawn();

        }
    }

    private void EnemySpawn()
    {
        int spawnIndex = UnityEngine.Random.Range(0, enemysToSpawn.Length);
        Instantiate(enemysToSpawn[spawnIndex], _respawnPoint[_currentSpawn].position, _respawnPoint[_currentSpawn].rotation);
        _instantiateCount++;
        _currentSpawn = UnityEngine.Random.Range(0,_respawnPoint.Length);
        if (_currentSpawn > _respawnPoint.Length -1)
        {
            _currentSpawn = 0;
        }


    }
}

