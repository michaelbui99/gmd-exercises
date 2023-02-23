using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject objectToFollow;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - objectToFollow.transform.position;
    }

    private void LateUpdate()
    {
        if (objectToFollow is null)
        {
            transform.Translate(new Vector3(0f, 0f, -2f));
            return;
        }

        transform.position = objectToFollow.transform.position + _offset;
    }
}