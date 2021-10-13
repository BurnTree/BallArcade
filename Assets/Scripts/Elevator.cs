using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float force = 10;
    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag(Tags.Player))
        {
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            playerRb.AddForce(Vector3.up * force);
        }
    }
}
