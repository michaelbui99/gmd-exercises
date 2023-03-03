using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private const float LockedXRotation = 90f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void LateUpdate()
    {
        var playerPosition = player.transform.position;
        var cameraTransform = transform;
        
        cameraTransform.position =
            new Vector3(playerPosition.x, cameraTransform.position.y, playerPosition.z);
    }
}