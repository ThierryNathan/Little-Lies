using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public float pushPower = 2.0f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rgdb = hit.collider.attachedRigidbody;

        if (rgdb == null || rgdb.isKinematic)
        {
            return;   
        }   
        if (hit.moveDirection.y < -0.3)
        {
            return; 
        }     
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z); 
        rgdb.velocity = pushDir * pushPower;
    }
}
