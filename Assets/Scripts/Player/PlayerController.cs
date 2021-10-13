using System;
using Constants;
using UnityEngine;

public class PlayerController : DamageObject
{
    [SerializeField]
    protected float force = 100;
    [SerializeField]
    private float jumpForce = 500;

    private Rigidbody _rb;
    private bool _canJump;
    private GameObject camera;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckCamera();
    }

    void CheckCamera()
    {
        if (camera == null)
        {
            camera = GameObject.FindGameObjectWithTag(Tags.Camera);
        }
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
            _rb.AddForce(Time.deltaTime * force * vectorDirection);

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            Debug.Log("Jump");
            _canJump = false;
            _rb.AddForce(jumpForce * Vector3.up);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        CheckDamage(other);
        CheckJumpPossibility(other);
    }

    private void OnCollisionStay(Collision other)
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