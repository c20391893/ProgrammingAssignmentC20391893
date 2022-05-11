using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject TeleportTo1;
    public GameObject TeleportTo2;
    public GameObject TeleportTo3;
    public GameObject TeleportTo4;
    public GameObject TeleportTo5;
    public GameObject TeleportTo6;
   
 
    // Start is called before the first frame update

    private void Start()
    {
   
    }
    private void OnTriggerEnter(Collider collision)
    {
        CharacterController CC = player.GetComponent<CharacterController>();
        if (collision.gameObject.CompareTag("Teleporter1"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo1.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;
            
        }

        if (collision.gameObject.CompareTag("Teleporter2"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo2.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;

        }

        if (collision.gameObject.CompareTag("Teleporter3"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo3.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;

        }

        if (collision.gameObject.CompareTag("Teleporter4"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo4.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;

        }

        if (collision.gameObject.CompareTag("Teleporter5"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo5.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;

        }

        if (collision.gameObject.CompareTag("Teleporter6"))
        {
            CC.enabled = false;
            player.transform.position = TeleportTo6.transform.position;
            FindObjectOfType<audioManager>().Play("Teleport");
            CC.enabled = true;

        }


    }
}
