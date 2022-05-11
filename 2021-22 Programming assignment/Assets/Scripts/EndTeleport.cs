using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTeleport : MonoBehaviour
{
    public GameManager gm;
    public GameObject winner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        winner.SetActive(true);
        gm.Finish();
    }
}
