using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject teleporter;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        BC.isTrigger = true;
        BC.size = new Vector3(1, 4, 1);
        BC.center = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      // if(other.gameObject.tag=="Block")
      // {
            teleporter.SetActive(true);
       // }
       
    }

    private void OnTriggerExit(Collider other)
    {
        teleporter.SetActive(false);
    }
}
