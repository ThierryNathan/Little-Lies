using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStart : MonoBehaviour
{
    public float timer = 0;
    public GameObject maya;

    void Update() 
    {
        timer += Time.deltaTime;
        if (timer <= 2)
        {
            maya.GetComponent<Animator>().Play("Standing Up");
            
        }
        else
        {
            Destroy(this);
        }
    }  
}
