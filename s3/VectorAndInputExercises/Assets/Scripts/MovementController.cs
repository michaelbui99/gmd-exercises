using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        if (vertical != 0f)
        {
            transform.Translate(Vector3.forward * (vertical * (speed * Time.deltaTime)));
        }

        if (horizontal != 0f)
        {
            transform.Translate(Vector3.right * (horizontal * (speed * Time.deltaTime)));
        }
    }
}