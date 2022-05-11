using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerInteract : MonoBehaviour
{
    public AudioClip Audio;
    public AudioSource sound;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
   // public Sound[] sounds;
   
    public EnemyStats stats1;
    public EnemyStats stats2;
    public EnemyStats stats3;
    public EnemyStats stats4;
    public EnemyStats stats5;
    public EnemyStats stats6;
   public bool enemy1here;
    public bool enemy2here;
   public bool enemy3here;
    public bool enemy4here;
    public bool enemy5here;
    public bool enemy6here;
    public float radius = 3;
  //  public LayerMask whatisEnemy1;
  //  public LayerMask whatisEnemy2;
  //  public LayerMask whatisEnemy3;
  //  public LayerMask whatisEnemy4;
  //  public LayerMask whatisEnemy5;
   // public LayerMask whatisEnemy6;
    private BoxCollider BC;
    private void Start()
    {
        BC = GetComponent<BoxCollider>();
    // sound=gameObject.GetComponent<AudioSource>();
        //sound.clip = Audio;
      //  sound.volume = volume;
      //  sound.pitch = pitch;
    }



    /*  public void FixedUpdate()
     {

         enemy1here = Physics.CheckSphere(transform.position, radius, whatisEnemy1);
         enemy2here = Physics.CheckSphere(transform.position, radius, whatisEnemy2);
         enemy3here = Physics.CheckSphere(transform.position, radius, whatisEnemy3);
         enemy4here = Physics.CheckSphere(transform.position, radius, whatisEnemy4);
         enemy5here = Physics.CheckSphere(transform.position, radius, whatisEnemy5);
         enemy6here = Physics.CheckSphere(transform.position, radius, whatisEnemy6);
   }
 */
public void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Enemy1")
    {
             enemy1here = true;
            enemy2here = false;
            enemy3here = false;
            enemy4here = false;
            enemy5here = false;
            enemy6here = false;
        }
    else if (other.gameObject.tag == "Enemy2")
    {
        enemy2here = true;
            enemy1here = false;
           
            enemy3here = false;
            enemy4here = false;
            enemy5here = false;
            enemy6here = false;
        }
    else if (other.gameObject.tag == "Enemy3")
    {
        enemy3here = true;
            enemy1here = false;
            enemy2here = false;
         
            enemy4here = false;
            enemy5here = false;
            enemy6here = false;
        }
    else if (other.gameObject.tag == "Enemy4")
    {
        enemy4here = true;
            enemy1here = false;
            enemy2here = false;
            enemy3here = false;
           
            enemy5here = false;
            enemy6here = false;
        }
    else if (other.gameObject.tag == "Enemy5")
    {
            enemy5here = true;
            enemy1here =false;
            enemy2here = false;
            enemy3here = false;
            enemy4here = false;
            
            enemy6here = false;
        }
    else if (other.gameObject.tag == "Enemy6")
    {
             enemy6here = true;
            enemy1here = false;
            enemy2here = false;
            enemy3here = false;
            enemy4here = false;
            enemy5here = false;
         
        }

        else
        {
            enemy6here = false;
            enemy1here = false;
            enemy2here = false;
            enemy3here = false;
            enemy4here = false;
            enemy5here = false;
        }

    

  //  enemy3here = Physics.CheckSphere(transform.position, radius, whatisEnemy3);
  //  enemy4here = Physics.CheckSphere(transform.position, radius, whatisEnemy4);
 //   enemy5here = Physics.CheckSphere(transform.position, radius, whatisEnemy5);
 //   enemy6here = Physics.CheckSphere(transform.position, radius, whatisEnemy6);
}
    public void OnTriggerExit(Collider other)
    {
        enemy6here = false;
        enemy1here = false;
        enemy2here = false;
        enemy3here = false;
        enemy4here = false;
        enemy5here = false;
    }
    public void Attack()
{

 if(enemy1here)
 {
     stats1.TakeDamage(10);
     //stats2.TakeDamage(10);
     Debug.Log("ENEMY1");

 }

 if (enemy2here)
 {
   //  stats1.TakeDamage(10);
     stats2.TakeDamage(10);
     Debug.Log("ENEMY2");

 }

 if (enemy3here)
 {
     //  stats1.TakeDamage(10);
     stats3.TakeDamage(10);
     Debug.Log("ENEMY3");

 }

 if (enemy4here)
 {
     //  stats1.TakeDamage(10);
     stats4.TakeDamage(10);
     Debug.Log("ENEMY4");

 }

 if (enemy5here)
 {
     //  stats1.TakeDamage(10);
     stats5.TakeDamage(10);
     Debug.Log("ENEMY5");

 }

 if (enemy6here)
 {
     //  stats1.TakeDamage(10);
     stats6.TakeDamage(10);
     Debug.Log("ENEMY6");

 }


}
void OnDrawGizmosSelected()
 {
 Gizmos.color = Color.white;
 Gizmos.DrawWireSphere(transform.position, radius);
}



}
