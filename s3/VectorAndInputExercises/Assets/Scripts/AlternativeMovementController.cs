using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private bool _shouldReverse = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("MyVertical");
        var horizontal = Input.GetAxis("MyHorizontal");

        if (Input.GetButton("Jump"))
        {
            _shouldReverse = !_shouldReverse;
        }

        var movementScalar = GetMovementScalar();
        if (vertical != 0f)
        {
            transform.Translate(Vector3.forward * (movementScalar * (vertical * (speed * Time.deltaTime))));
        }

        if (horizontal != 0f)
        {
            transform.Translate(Vector3.right * (movementScalar * horizontal * (speed * Time.deltaTime)));
        }
    }

    private int GetMovementScalar()
    {
        if (_shouldReverse)
        {
            return -1;
        }

        return 1;
    }
}