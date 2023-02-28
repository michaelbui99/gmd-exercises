using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private float jumpSpeed = 1.0f;

    private bool _jumping = false;
    private event EventHandler onGrounded;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        var existingRigidBody = gameObject.GetComponent<Rigidbody>();

        if (existingRigidBody is null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            ToggleRigidBody(_rigidbody);
            return;
        }

        _rigidbody = existingRigidBody;
        if (!_rigidbody.isKinematic)
        {
            ToggleRigidBody(_rigidbody);
        }
    }

    void Start()
    {
        onGrounded += (_, _) =>
        {
            _jumping = false;
            ToggleRigidBody(_rigidbody);
            Debug.Log("Grounded");
        };
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            OnGrounded();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_jumping)
            {
                return;
            }

            ToggleRigidBody(_rigidbody);
            _rigidbody.AddForce(Vector3.up * jumpSpeed);
            _jumping = true;
        }
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * (moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.back * (moveSpeed * Time.deltaTime);
        }
    }

    private void ToggleRigidBody(Rigidbody rb)
    {
        rb.isKinematic = !rb.isKinematic;
        rb.detectCollisions = !rb.detectCollisions;
    }

    private void OnGrounded()
    {
        onGrounded?.Invoke(this, EventArgs.Empty);
    }
}