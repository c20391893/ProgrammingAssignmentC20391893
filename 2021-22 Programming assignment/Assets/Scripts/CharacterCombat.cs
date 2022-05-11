using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    // Start is called before the first frame update
    public void Attack(CharacterStats targetStats)
    {
       // targetStats.TakeDamage(10);
      //  Debug.Log(transform.name + " takes " +   " damage");
    }
}

