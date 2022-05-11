using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushStateMachine:StateMachineBehaviour
{
    private GameObject player;
    private thirdpersonmovement tpm;

    private void Awake()
    {
     //   player = GameObject.Find("GameBandit");
     //   tpm = player.GetComponent<thirdpersonmovement>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("GameBandit");
        tpm = player.GetComponent<thirdpersonmovement>();
       // if ()
     //   {
          //  FindObjectOfType<audioManager>().Play("MovingBlock");
       // }
      //  else 
       // {
         //  FindObjectOfType<audioManager>().StopPlaying("MovingBlock");
      //  }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     //   player = GameObject.Find("GameBandit");
     //   tpm = player.GetComponent<thirdpersonmovement>();
     //   FindObjectOfType<audioManager>().StopPlaying("MovingBlock");

    }
}
