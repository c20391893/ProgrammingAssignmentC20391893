using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollecting : MonoBehaviour
{
    public GameManager gm;
    public List<object> inventory;
    public int CapacityLimit = 1;
    public bool Blueorbcollected = false;
    public bool RedorbCollected = false;
    public CharacterStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<object>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("BlueOrb"))
        {


            FindObjectOfType<audioManager>().Play("Orbs");
          
            gm.gameStatus.BlueActive = true;

          //  object itemType = collision.gameObject.GetComponent<Item>().itemType;
          //  print("Item collected a:" + itemType);
         //   inventory.Add(itemType);
        //    print("Inventory length" + inventory.Count);
           // Destroy(collision.gameObject);



        }
        else if (collision.CompareTag("RedOrb"))
        {
            gm.gameStatus.redActive = true;
            FindObjectOfType<audioManager>().Play("Orbs");
        }

     
    }

    private void OnTriggerExit(Collider collision)
    {
          if (collision.CompareTag("Coin"))
        {
            gm.gameStatus.score += 10;
            FindObjectOfType<audioManager>().Play("Coins");
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("HealthPotion"))
        {
            if (gm.gameStatus.health < myStats.maxHealth)
            {



                myStats.RecoverHealth(10);
                FindObjectOfType<audioManager>().Play("Potion");
                Destroy(collision.gameObject);
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
