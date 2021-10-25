using System;
using Constants;
using UnityEngine;

public class PlayerController : DamageObject
{
    [SerializeField]
    protected float speed = 200;
    [SerializeField]
    private float jumpForce = 500;
    private bool _canJump;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vectorDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            vectorDirection.z += 1f;
        if (Input.GetKey(KeyCode.S))
            vectorDirection.z += -1f;
        if (Input.GetKey(KeyCode.A))
            vectorDirection.x += -1f;
        if (Input.GetKey(KeyCode.D))
            vectorDirection.x += 1f;
        if(vectorDirection != Vector3.zero)
            _rb.AddForce(Time.deltaTime * speed * vectorDirection);

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _canJump = false;
            _rb.AddForce(jumpForce * Vector3.up);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        CheckDamage(other);
        CheckJumpPossibility(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckDeadZone(other);
    }

    private void CheckJumpPossibility(Collision ground)
    {
        if (ground.gameObject.CompareTag(Tags.Ground))
        {
            _canJump = true;
        }
    }
}