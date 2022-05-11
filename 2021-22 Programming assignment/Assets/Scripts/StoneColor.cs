using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneColor : MonoBehaviour
{
    public Material stone;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = stone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
