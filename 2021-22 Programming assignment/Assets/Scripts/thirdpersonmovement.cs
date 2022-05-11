using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class thirdpersonmovement : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    public CharacterController controller;
    public GameManager gm;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundmask;
    public LayerMask groundmask2;
    public float speed = 6f;
    public float jump = 3f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    public Transform respawnPoint;
    public bool shouldAttack;
    private bool toPause;
    public bool alive;
    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;
    public GameObject pauseMenu;
    public GameObject GameOver;
    public GameObject title;
    public bool isPaused;
    public Vector3 direction;
    public float horizontal;
    public float vertical;
    public GameObject healthBar;
    public GameObject score;
    public GameObject hb;
    public bool push;
   // public GameObject score;
   
    // public UnityEvent Pause;
    //  public UnityEvent UnPause;
    //  public UnityEvent Quit;
    void Start()
    {

        anim = GetComponent<Animator>();
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(push);
        if (isPaused == false)
        {


            anim.SetBool("alive", alive);
            if (alive == true)
            {



                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                }
                horizontal = Input.GetAxisRaw("Horizontal");
                 vertical = Input.GetAxisRaw("Vertical");
                anim.SetFloat("vAxisInput", vertical);
                anim.SetFloat("hAxisInput", horizontal);
              direction = new Vector3(horizontal, 0f, vertical).normalized;
                anim.SetBool("attack", shouldAttack);
                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);

                }
                /* if (Input.GetKeyDown(KeyCode.C))
                 {
                     Debug.Log("Press");
                     anim.SetBool("attack", true);
                 }
                */

                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Press");
                    shouldAttack = true;
                }

              

                else
                {
                    shouldAttack = false;
                }
                if (Input.GetButtonDown("Jump") & isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
                    anim.SetBool("SpaceBarJump", true);
                }
                else
                {
                    anim.SetBool("SpaceBarJump", false);
                }


                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);

                Debug.Log(toPause);
            }

        }

        if (alive == true)
        {


            if (Input.GetKeyDown(KeyCode.P))
            {
                // Debug.Log("Press");
                if (!toPause)
                {
              
                    toPause = true;
                   // FindObjectOfType<audioManager>().StopPlaying("Theme");
                }
                else if (toPause)
                {
                 
                    toPause = false;
                  //  FindObjectOfType<audioManager>().Play("Theme");
                }
                
            }

            if(!toPause)
            {
                UnPauseGame();
            }

            else if(toPause)
            {
            
                PauseGame();
            }
        }

    }
    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
       healthBar.SetActive(false);
        score.SetActive(false);
        FindObjectOfType<audioManager>().PausePlay("Theme");
        FindObjectOfType<audioManager>().PausePlay("PlayerWalking");
        FindObjectOfType<audioManager>().PausePlay("PlayerCombat");
        Time.timeScale = 0f;
        toPause = true;
    }

    public void UnPauseGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        healthBar.SetActive(true);
        score.SetActive(true);
        FindObjectOfType<audioManager>().UnPausePlay("Theme");
        FindObjectOfType<audioManager>().UnPausePlay("PlayerWalking");
        FindObjectOfType<audioManager>().UnPausePlay("PlayerCombat");
        
        Time.timeScale = 1f;
        toPause = false;
    }
    public void StartGame()
    {
      //  title.SetActive(false);
       // Time.timeScale = 1f;
    }

    public void OnApplicationQuit()
    {
        // pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gm.SaveGameStatus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       // TitleMenu();
    }

    public void TitleMenu()
    {
      //  Time.timeScale = 0f;
      //  title.SetActive(true);
    }


    public void Death()
    {
        healthBar.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        alive = false;
        FindObjectOfType<audioManager>().Play("PlayerDeath");
        gameObject.tag = "Untagged";
        gameObject.layer = 0;
      //  gm.GameOver();
    }


    public void EndGame()
    {
        gm.GameOver();
    }
}