using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Animator anim;
    public bool Warning;
    public Material warning;
    public Material normal;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider bc = gameObject.GetComponent<BoxCollider>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnTriggerEnter(Collider other)
    {
        anim.SetBool("falling", true);
        GetComponent<Renderer>().material = warning;
    }

    void OnTriggerExit(Collider other)
    {
        anim.SetBool("falling", false);
        GetComponent<Renderer>().material = normal;
    }
}
