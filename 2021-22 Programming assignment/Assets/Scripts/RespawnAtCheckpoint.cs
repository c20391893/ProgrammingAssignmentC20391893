using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAtCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform pos1;
    [SerializeField] public Transform pos2;
    [SerializeField] public Transform pos3;
    [SerializeField] public Transform player;
    public CharacterStats CS;
    public CharacterController CC;
    public int checkpointCount = 0;
    public GameObject checkpointText;
    public GameManager gm;
    private IEnumerator coroutine;

    private void Start()
    {
        //  CC = player.GetComponent<CharacterController>();
        coroutine = Wait(2);
    }
    public void OnTriggerEnter(Collider other)
    {
        // CharacterController CC = player.GetComponent<CharacterController>();
        if (other.gameObject.tag == "Checkpoint1")
        {
            BoxCollider BC = other.gameObject.GetComponent<BoxCollider>();

            BC.enabled = false;
            gm.gameStatus.spawnPoint = 1;
            checkpointText.SetActive(true);
            StartCoroutine(coroutine);
        }

        if (other.gameObject.tag == "Checkpoint2")
        {
            BoxCollider BC = other.gameObject.GetComponent<BoxCollider>();

            BC.enabled = false;
            gm.gameStatus.spawnPoint = 2;
            checkpointText.SetActive(true);
            StartCoroutine(coroutine);
        }
        if (other.gameObject.tag == "Respawn")
        {
            gm.Respawn();
        }

        if(other.gameObject.tag=="Lava")
        {
            gm.Respawn();
           CS.TakeDamage(10);

            if(gm.gameStatus.health==0)
            {
                CS.GameOver();
            }
        }

    }
    private IEnumerator Wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            checkpointText.SetActive(false);
        }
    }

    /* public void Respawn()
 {


     if (checkpointCount == 1)
     {
         CC.enabled = false;
         player.transform.position = pos2.transform.position;
         CC.enabled = true;
     }



    else if (checkpointCount == 2)
     {
         CC.enabled = false;
         player.transform.position = pos3.transform.position;
         CC.enabled = true;
     }



     else 
     {
         CC.enabled = false;
         player.transform.position = pos1.transform.position;
         CC.enabled = true;
     }
 }
*/

}
