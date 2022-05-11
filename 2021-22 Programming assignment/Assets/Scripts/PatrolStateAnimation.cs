using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;




public class PatrolStateAnimation : StateMachineBehaviour
{
    private AudioSource audio;
    public AudioClip clip;
   // private EnemyController EC;
   // private bool play;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
       
        audio = animator.GetComponentInParent<AudioSource>();
       
        
            audio.clip = clip;
        audio.PlayDelayed(1);
           
        
      
     

    }



    // Start is called before the first frame update


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio.Stop();
    }
}

 
