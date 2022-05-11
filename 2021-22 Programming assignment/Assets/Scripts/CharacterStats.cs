
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 30;
    // public int currentHealth{ get; private set; }
    public int currentHealth;
    public CharacterHealthBarScript healthBar;
    public GameManager gm;
    public Stat damage;
    public Stat armour;
    public thirdpersonmovement tpm;
    private bool Over;


    private void Awake()
    {
        // gm=GameManager.instance;
        gm.Start();
        //gm.gameStatus.health = maxHealth;
        //  currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(gm.gameStatus.health);
    }

    /* private void Update()
    {
      //  gm.gameStatus.health = currentHealth;
    if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
       
    }
    */


    public void TakeDamage(int damage)
    {

        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        gm.gameStatus.health -= damage;
        healthBar.SetHealth(gm.gameStatus.health);
        FindObjectOfType<audioManager>().Play("PlayerDamage");
        Debug.Log(transform.name + " takes " + damage + " damage.");
        if (gm.gameStatus.health <= 0)
        {
            tpm.Death();
        }
    }

    public void RecoverHealth(int potion)
    {
        if (gm.gameStatus.health < maxHealth)
        {
            potion = Mathf.Clamp(potion, 0, int.MaxValue);
            gm.gameStatus.health += potion;
            healthBar.SetHealth(gm.gameStatus.health);

        }
        else if (gm.gameStatus.health >= maxHealth)
        {
          // gm.gameStatus.health = maxHealth;
           // healthBar.SetHealth(gm.gameStatus.health);
        }
    }

    public void Die()
    {

    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        tpm.GameOver.SetActive(true);
        gm.gameStatusUI.gameObject.SetActive(false);
        // Debug.Log(transform.name + " died");
        // Destroy(gameObject);
        //   gm.Respawn();
        // gm.gameStatus.health = maxHealth;
        //  healthBar.SetMaxHealth(maxHealth);
        //healthBar.SetHealth(gm.gameStatus.health);

    }
}