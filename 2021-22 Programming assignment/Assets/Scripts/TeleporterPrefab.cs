using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        BC.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
