using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public EnemyController EC;
    public HealthBarScript healthBar;
    //public GameManager gm;
    public Stat damage;
    public Stat armour;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Update()
    {
        /*  if(Input.GetKeyDown(KeyCode.T))
             {
                 TakeDamage(10);
             }
            */
    }

    public void TakeDamage(int damage)
    {

        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(transform.name + " takes " + damage + " damage.");
        if (currentHealth <= 0)
        {
            EC.Die();
        }
    }

  
}
