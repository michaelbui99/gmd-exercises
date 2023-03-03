using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float rotateSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.up, -Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }
    }
}