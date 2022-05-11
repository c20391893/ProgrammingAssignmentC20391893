using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingScript : MonoBehaviour
{
  //  BoxCollider bc;
   public Animator anim;
    private thirdpersonmovement tpm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        tpm = GetComponent<thirdpersonmovement>();
       BoxCollider bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
          //  anim.SetBool("Pushing", true);
            if(tpm.push==true)
            {
                anim.SetBool("Pushing", true);
              //  FindObjectOfType<audioManager>().Play("MovingBlock");
            }

            else if(tpm.push==false)
            {
              //  anim.SetBool("Pushing", false);
              //  FindObjectOfType<audioManager>().StopPlaying("MovingBlock");
            }
        }

       
    }

    void OnTriggerExit(Collider other)
    {
      anim.SetBool("Pushing", false);
      //  FindObjectOfType<audioManager>().StopPlaying("MovingBlock");
    }
}
