using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    public CubelightRed CLR;
    public CubelightBlue CLB;
    // Start is called before the first frame update
    void Start()
    {
      //  BoxCollider BC = gameObject.AddComponent<BoxCollider>();
      //  BoxCollider BCT = gameObject.AddComponent<BoxCollider>();
       // BCT.isTrigger = true;
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (CLR.RedCubeactive == true && CLB.BlueCubeactive == true)
        {
           
            anim.SetBool("Open", true);
           // FindObjectOfType<audioManager>().Play("DoorOpen");
        }


    }

    
}
