using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject mole;

    private bool _gameOver = false;
    private int _molesSpawned = 0;


    private DateTime _lastMoleSpawnTime;

    // Start is called before the first frame update
    private void Start()
    {
        _lastMoleSpawnTime = DateTime.UtcNow;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_gameOver && _molesSpawned - Mole.Score >= 3)
        {
            _gameOver = true;
            Debug.Log("Game Over");
        }

        if (_gameOver || !ShouldSpawnMole())
        {
            return;
        }

        SpawnMole();
        _lastMoleSpawnTime = DateTime.UtcNow;
    }

    private bool ShouldSpawnMole()
    {
        return DateTime.UtcNow - _lastMoleSpawnTime >= TimeSpan.FromSeconds(2);
    }

    private void SpawnMole()
    {
        GameObject newMole = Instantiate(mole);
        newMole.transform.position = new Vector3(Random.Range(-9f, 9f), 0, Random.Range(-5f, 5f));
        _molesSpawned++;
        Destroy(newMole, 2f);
    }
}