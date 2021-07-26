using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject maya;
    public GameObject climb;
    [SerializeField] public FreezeZ freezeZ;
    [SerializeField] public FreezeX freezeX;

    public float timer = 0;
    void Update()
    {
        

        if (Input.GetMouseButtonDown(1) && freezeZ.isInside == true)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;

            maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

            maya.GetComponent<Animator>().SetBool("Pushing", true);
            
            climb.GetComponent<BoxCollider>().enabled = false;

            timer += Time.deltaTime;
        } 
        else if(Input.GetMouseButtonDown(1) && freezeX.isInside == true)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;

            maya.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            
            maya.GetComponent<Animator>().SetBool("Pushing", true);

            climb.GetComponent<BoxCollider>().enabled = false;

            timer += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1) || freezeZ.isInside == false && freezeX.isInside == false)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

            maya.GetComponent<Animator>().SetBool("Pushing", false); 

            
        } 

        if (Input.GetMouseButtonUp(1)){timer = 0;}
            

        if (maya.GetComponent<Animator>().GetBool("Pushing") == false)
        {
            
            if (timer == 0)
            {
                climb.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
