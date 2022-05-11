using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatStateMachine : StateMachineBehaviour
{
  //  private AudioClip clip1;
   // private AudioClip clip2;
    private AudioSource audio;
    private GameObject player;
    private PlayerInteract pl;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        // Get access to GetComponentsInParent, this will return an array
        audio = animator.GetComponentInParent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        pl = player.GetComponent<PlayerInteract>();

        if(pl.enemy1here||pl.enemy2here || pl.enemy3here || pl.enemy4here || pl.enemy5here || pl.enemy6here)
        {
            Debug.Log("Punch");
          //  pl.Audio[0].Play();
        }

        else
        {
        //  pl.Audio[1].Play();
        }
        FindObjectOfType<audioManager>().Play("PlayerCombat");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Get access to GetComponentsInParent, this will return an array
        FindObjectOfType<audioManager>().StopPlaying("PlayerCombat");
        // PLay audio file at index 0 (Door open)
        //   audio[0].Stop();
    }
}
