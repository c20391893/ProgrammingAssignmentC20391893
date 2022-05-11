using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HealthPotion", menuName = "HealthPotion")]
public class HealthPotion : ScriptableObject
{
    public string PrefabName;
   public int numberOfPrefabsToCreate;
   public Vector3[]  HPspawnPoints;
   // public GameObject baseShape;
  //  public CharacterStats myStats;
}
