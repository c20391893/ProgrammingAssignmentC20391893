using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStateMachine : StateMachineBehaviour
{
    //   private AudioSource[] audio;
    private thirdpersonmovement tpm;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tpm = animator.GetComponent<thirdpersonmovement>();
        // Get access to GetComponentsInParent, this will return an array
     //   audio = animator.GetComponentsInParent<AudioSource>();
        // PLay audio file at index 0 (Door open)
      //  audio[0].Play();
        FindObjectOfType<audioManager>().Play("PlayerWalking");
        tpm.push = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tpm = animator.GetComponent<thirdpersonmovement>();
        // Get access to GetComponentsInParent, this will return an array
        tpm.push = false;
        // PLay audio file at index 0 (Door open)
       // audio[0].Stop();
        FindObjectOfType<audioManager>().StopPlaying("PlayerWalking");
    }
}
