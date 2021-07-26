using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cutscene : MonoBehaviour
{   
    public GameObject otherobj;
    public string scr;
    public float timer = 0;


    void Update() 
    {
        timer += Time.deltaTime;
        if(timer >= 4.21)
        {
            ActiveMove();
            Destroy(this);
        } 
    }

   private void ActiveMove()
   {
        (otherobj.GetComponent(scr) as MonoBehaviour).enabled = true;
   }
}
