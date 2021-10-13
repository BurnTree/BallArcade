using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    [SerializeField]
    private Vector3 _distance;
    void Update()
    {
        CheckTarget();
        FollowTarget();
        CameraRotation();
    }

    void CheckTarget()
    {
        if (target == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag(Tags.Player);
            if (playerObject)
                target = playerObject.transform;
        }
    }

    void FollowTarget()
    {
        if(target != null)
            this.transform.position = target.position - _distance;
    }

    void CameraRotation()
    {
        Vector3 vectorRotation = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            vectorRotation.y += -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            vectorRotation.y += 1f;
        if (vectorRotation != Vector3.zero)
        {
            transform.Rotate(vectorRotation);
            Debug.Log(transform.forward);
        }
    }
}
