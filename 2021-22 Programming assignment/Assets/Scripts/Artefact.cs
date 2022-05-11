using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefact : MonoBehaviour
{
    public GameManager gm;
 //   public GameObject winner;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<audioManager>().Play("Gem");
        gm.gameStatus.score +=50;
   
    //  gm.Finish();
        
      Destroy(gameObject);
    }
}
