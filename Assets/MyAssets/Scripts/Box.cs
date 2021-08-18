using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiasGames.ThirdPersonSystem
{
    public class Box : MonoBehaviour
    {
        public GameObject maya;
        public GameObject climb;
        public GameObject box;
        public GameObject room;
        [SerializeField] public FreezeZ freezeZ;
        [SerializeField] public FreezeX freezeX;
        private float After_m_MovingTurnSpeed = 0.0f;
        void Update()
        {
            if (Input.GetMouseButtonDown(1) && freezeZ.isInside == true)
            {
                //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY
                //| RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;
                this.GetComponent<Rigidbody>().isKinematic = true;

                //maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ
                //| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

                maya.GetComponent<Animator>().SetBool("Pushing", true);

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 0;

                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 0;

                box.transform.parent = maya.transform;
            } 

            else if(Input.GetMouseButtonDown(1) && freezeX.isInside == true)
            {
                //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY
                //| RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;
                this.GetComponent<Rigidbody>().isKinematic = true;

                //maya.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionX
                //| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                
                maya.GetComponent<Animator>().SetBool("Pushing", true);

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 0;
                
                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 0;

                box.transform.parent = maya.transform;
            }

            if (Input.GetMouseButtonUp(1) || freezeZ.isInside == false && freezeX.isInside == false)
            {
                //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
                //| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

                maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

                maya.GetComponent<Animator>().SetBool("Pushing", false); 

                box.transform.parent = room.transform;

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 360;
                
                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 180;

                this.GetComponent<Rigidbody>().isKinematic = false;
            } 
        }
        
    }
}
