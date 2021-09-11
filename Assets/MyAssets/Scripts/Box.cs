using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiasGames.ThirdPersonSystem
{
    public class Box : MonoBehaviour
    {
        public GameObject maya;
        public GameObject climb;
        public GameObject room;
        [SerializeField] public FreezeZ freezeZ;
        [SerializeField] public FreezeX freezeX;
        public string strafe; 
        public float timer = 0;

        Animator m_Animator;
        public string m_ClipName;
        AnimatorClipInfo[] m_CurrentClipInfo;

        void Start()
        {
            m_Animator = maya.GetComponent<Animator>();
        }
        void Update()
        {
            setKinematic();
            StartCoroutine(getAnimation());
            if (freezeZ.isInside == true || freezeX.isInside == true)
            {
                timer = 0;
            }

            if (Input.GetButtonDown("Zoom") && freezeZ.isInside == true)
            {
                setKinematic();
                (maya.GetComponent(strafe) as MonoBehaviour).enabled = true;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;

                maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 0;

                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 0;

                this.transform.parent = maya.transform;
                
            } 

            else if(Input.GetButtonDown("Zoom") && freezeX.isInside == true)
            {
                //GetMouseButtonDown(1)
                setKinematic();
                (maya.GetComponent(strafe) as MonoBehaviour).enabled = true;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ |  RigidbodyConstraints.FreezeRotationX;

                maya.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionX
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 0;
                
                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 0;

                this.transform.parent = maya.transform;
                
            }

            if (Input.GetButtonUp("Zoom") || freezeZ.isInside == false && freezeX.isInside == false)
            {
                timer += Time.deltaTime;
                if (timer >= 1)
                {
                    //(maya.GetComponent(strafe) as MonoBehaviour).enabled = false;
                }

                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

                maya.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY
                | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

                this.transform.parent = room.transform;

                maya.GetComponent<ThirdPersonSystem>().m_MovingTurnSpeed = 360;
                
                maya.GetComponent<ThirdPersonSystem>().m_StationaryTurnSpeed = 180;

                
            } 
        }

        IEnumerator getAnimation()
        {
            m_CurrentClipInfo = m_Animator.GetCurrentAnimatorClipInfo(0);
            
            if (m_Animator.GetCurrentAnimatorClipInfo (0).Length > 0)
            {
                m_ClipName = m_CurrentClipInfo[0].clip.name;
            }
            while (m_Animator.GetCurrentAnimatorClipInfo (0).Length == 0) 
            {
                print ("***************ITS NULL, LETS WAIT");
                yield return null;
            }
        }

        void setKinematic()
        {
            if (m_ClipName == "Pull Heavy Object")
            {
                this.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
