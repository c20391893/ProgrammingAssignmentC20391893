using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionInteract : MonoBehaviour
{
    private GameObject player;
   private CharacterStats myStats;
    private GameObject gameManager;
    private GameManager gm;
    private SphereCollider col;
    // Start is called before the first frame update
    void Awake()
    {
        col = gameObject.AddComponent<SphereCollider>();
        
        player = GameObject.Find("GameBandit");
        myStats = player.GetComponent<CharacterStats>();
        gameManager = GameObject.Find("GameManager");
        gm= gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      //  col.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            if (gm.gameStatus.health<myStats.maxHealth)
            {
               
                FindObjectOfType<audioManager>().Play("Potion");
               
                myStats.RecoverHealth(10);
               
                Destroy(gameObject);
            }

            //gm.gameStatus.health++;
            // Debug.Log(gm.gameStatus.health);
            else
            {
                Debug.Log("Health full");
            }
            
           
                 
               
            
        }

        

            
        
       
    }
}
