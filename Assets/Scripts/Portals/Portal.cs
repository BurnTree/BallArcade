using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal portalAim;
    private bool isActive = true;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag(Tags.Player) && isActive && !ReferenceEquals(portalAim, null))
        {
            Transform transform = player.transform;
            Vector3 aimVector = portalAim.transform.position;
            transform.position = new Vector3(aimVector.x, aimVector.y + player.transform.lossyScale.y, aimVector.z);
            portalAim.isActive = false;
        }
        
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag(Tags.Player))
        {
            isActive = true;
        }
    }
}
