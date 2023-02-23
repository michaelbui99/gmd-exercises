using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    public float ExpansionFactor { get; set; } = 0.3f;

    public int ExplosionDuration { get; set; } = 3;
    
    private DateTime _startTime;
    private Vector3 _scaleScalar;

    public void OnStart()
    {
        _startTime = DateTime.UtcNow;
    }
    void Start()
    {
        _scaleScalar = new Vector3(ExpansionFactor, ExpansionFactor, ExpansionFactor);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale += _scaleScalar;

        if (GetTimeDiffInSeconds() >= ExplosionDuration)
        {
            Destroy(gameObject);       
        }
    }

    private int GetTimeDiffInSeconds()
    {
        return (int) (DateTime.UtcNow - _startTime).TotalSeconds;
    }
}