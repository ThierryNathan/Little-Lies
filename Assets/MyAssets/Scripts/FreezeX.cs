using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeX : MonoBehaviour
{
    public GameObject box;
    public bool isInside = false;
    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
        {
           isInside = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
         if (other.tag == "Player")
        {
           isInside = false; 
        }
    }
}
