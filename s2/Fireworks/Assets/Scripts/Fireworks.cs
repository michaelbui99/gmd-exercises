using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private int secondsUntilExplosion = 5;

    [SerializeField]
    private GameObject explosionPrefab;

    
    private GameObject _explosionInstance;

    private DateTime _startTime;


    // Start is called before the first frame update
    private void Awake()
    {
        _explosionInstance = Instantiate(explosionPrefab);
        _explosionInstance.SetActive(false);
    }

    void Start()
    {
        _startTime = DateTime.UtcNow;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            gameObject.transform.Translate(Vector3.up * speed);
        }

        if (GetTimeDiffInSeconds() >= secondsUntilExplosion)
        {
            _explosionInstance.SetActive(true);
            _explosionInstance.GetComponent<ExplosionController>().OnStart();
            _explosionInstance.gameObject.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }

    private int GetTimeDiffInSeconds()
    {
        return (int) (DateTime.UtcNow - _startTime).TotalSeconds;
    }
}