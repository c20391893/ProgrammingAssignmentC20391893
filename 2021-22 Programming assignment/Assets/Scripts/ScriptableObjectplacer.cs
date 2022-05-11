using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectplacer : MonoBehaviour
{
    [SerializeField] private HealthPotion HP;
    [SerializeField] private CharacterStats myStats;
    public GameObject HPbase;
    int instanceNumber = 1;
    private void Start()
    {
       Debug.Log(HP.HPspawnPoints);
        SpawnHealth();
    }


    void SpawnHealth()
    {

        int currentSpawnPointIndex = 0;
       for(int i=0;i<HP.numberOfPrefabsToCreate;i++)
        {
           GameObject Potion = Instantiate(HPbase, HP.HPspawnPoints[currentSpawnPointIndex], Quaternion.identity);
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % HP.HPspawnPoints.Length;
        }
    }
}
