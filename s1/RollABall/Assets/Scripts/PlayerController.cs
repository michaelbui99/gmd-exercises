using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject pickUpParent;

    private Rigidbody _rigidbody;
    private int _count;
    private float _movementX;
    private float _movementY;
    private event EventHandler onPickup;

    // Start is called before the first frame update
    void Start()
    {
        int totalPickUps = pickUpParent.transform.childCount;
        
        winTextObject.SetActive(false);
        
        _rigidbody = GetComponent<Rigidbody>();
        
        onPickup += (_, _) =>
        {
            _count++;
            SetCountText();
            if (_count >= totalPickUps)
            {
                winTextObject.SetActive(true);
            }
        };

        _count = -1;
        OnPickup(EventArgs.Empty);
    }

    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    // Called before physics is applied
    private void FixedUpdate()
    {
        Vector3 movementVector = new(_movementX, 0.0f, _movementY);
        _rigidbody.AddForce(movementVector * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PickUp"))
        {
            return;
        }

        other.gameObject.SetActive(false);
        OnPickup(EventArgs.Empty);
    }

    private void SetCountText()
    {
        countText.text = $"Count: {_count.ToString()}";
    }

    protected virtual void OnPickup(EventArgs e)
    {
        onPickup?.Invoke(this, e);
    }
}