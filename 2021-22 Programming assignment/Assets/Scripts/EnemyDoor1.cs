using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor1 : MonoBehaviour
{
    public float doorDeathCount;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameStatus.enemyCount>=doorDeathCount)
        {
            Destroy(gameObject);
        }
        Debug.Log(gm.gameStatus.enemyCount);
    }
}
