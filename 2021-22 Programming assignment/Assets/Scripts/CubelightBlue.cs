using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubelightBlue : MonoBehaviour
{
    public GameManager gm;
    public PlayerCollecting pc;
    public bool BlueCubeactive;
    public Material active;
    private float scaleX=3;
        private float scaleY=3;
    private float scaleZ=3;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider BC = gameObject.AddComponent<BoxCollider>();
        BoxCollider BCT = gameObject.AddComponent<BoxCollider>();
        BCT.isTrigger = true;
        BCT.size = new Vector3(scaleX, scaleY, scaleZ);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pc.Blueorbcollected == true)
        {
            gm.gameStatus.BlueLight = true;
            BlueCubeactive = true;
            GetComponent<Renderer>().material = active;
            FindObjectOfType<audioManager>().Play("CubeActive");

        }
    }
}
