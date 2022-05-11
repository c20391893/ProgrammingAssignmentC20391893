using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Material Stone;
    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationX  | RigidbodyConstraints.FreezeRotationZ;
        // rb.constraints=RigidbodyConstraints.FreezeRotationZ;
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        // rb.isKinematic = true;
        rb.mass = 10;
     //   GetComponent<Renderer>().material = Stone;

        PhysicMaterial stone = new PhysicMaterial("Stone");
        stone.bounciness = 0f;
        stone.staticFriction = 10f;
        stone.dynamicFriction = 10f;
        BC.material = stone;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
