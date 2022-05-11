using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public struct GameStatus
{
    //   public string playerName;
    public int health;
    public int spawnPoint;
    public int score;
    //public bool checkpoint1;
    public int highscore;
    public List<Vector3> Coins;
    public bool redActive;
    public bool BlueActive;
    public bool RedLight;
    public bool BlueLight;
    public bool Gemcollected;
    public int enemyCount;
    // public Slider slider;

}
public class GameManager : MonoBehaviour
{
  //  public float enemydeathcount;
    // public int score;
    public GameStatus gameStatus;
    public PlayerCollecting pc;
    public CubelightRed ClR;
    public CubelightBlue ClB;
    public Slider slider;
    public coinsPlacer cp;
    string filePath;
    const string FILE_NAME = "SaveStatus.json";
    public GameObject player;
    public RespawnAtCheckpoint RaC;
    private Vector3 startPos;
    private thirdpersonmovement tpm;
    public CharacterStats mystats;
    public Text gameStatusUI;
    public Text gameOverScore;
    public Text GameOverHighScore;
    public GameObject newhighscoreGameOver;
    public Text highscore;
    public Text winScore;
    public GameObject newHighscore;
    public GameObject GameOverscreen;
 //   public GameObject score;
    public GameObject redOrb;
    public GameObject blueOrb;
    public GameObject redBox;
    public GameObject blueBox;
    public GameObject Platform;
    public GameObject gem;
    public float enemyDeathCount;
    public float platformCount;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;


    // Start is called before the first frame update
    public void Awake()
    {
      
           
        
         //   Time.timeScale = 1;
        //tpm = player.GetComponent<thirdpersonmovement>();
        //ystats = player.GetComponent<CharacterStats>();
        //  gameStatus.spawnPoint = RaC.checkpointCount;
        // gameStatus.health = mystats.currentHealth;

    }

    void ShowStatus()
    {
         string message = "";
        //   message += "Player Name:" + gameStatus.playerName + "\n";
        //  message += "health:" + gameStatus.health + "\n";
        // message += "spawnPoint" + gameStatus.spawnPoint + "\n";
       // message += "coins" + gameStatus.score + "\n";
         // return message;
    }
    void Update()
    {
        DeathCount();
        // if(gameStatus.score>gameStatus.highscore)
        //  {
        //  gameStatus.score = gameStatus.highscore;
        // }
        //  int currentSpawnIndex = 0;
        // for (int i = 0; i < coinToPLace; i++)

        //    GameObject coinPrefab = Instantiate(coin, gameStatus.coins[i], Quaternion.identity);
        // currentSpawnIndex = (currentSpawnIndex + 1) % gameStatus.coins.Length;
        gameStatusUI.text = "SCORE: " + gameStatus.score + "\n";
        gameOverScore.text = "SCORE: " + gameStatus.score + "\n";
           GameOverHighScore.text= "HIGHSCORE: " + gameStatus.highscore + "\n";
        highscore.text = "HIGHSCORE: " + gameStatus.highscore + "\n";
        winScore.text = "SCORE: " + gameStatus.score + "\n";
        
        if(gameStatus.redActive==true)
        {
            pc.RedorbCollected = true;
            redOrb.SetActive(false);

        }

        if (gameStatus.BlueActive == true)
        {
            pc.Blueorbcollected = true;
            blueOrb.SetActive(false);

        }

        if(gameStatus.RedLight==true)
        {
            ClR.RedCubeactive = true;
           redBox.GetComponent<Renderer>().material = ClR.active;
        }

        if(gameStatus.BlueLight==true)
        {
            ClB.BlueCubeactive = true;
            blueBox.GetComponent<Renderer>().material = ClB.active;
        }
        if(gameStatus.Gemcollected==true)
        {
            gem.SetActive(false);
        }
        
    }

    public void Respawn()
    {




        if (gameStatus.spawnPoint == 1)
        {
            RaC.CC.enabled = false;
            player.transform.position = RaC.pos2.transform.position;
            RaC.CC.enabled = true;
        }



        else if (gameStatus.spawnPoint == 2)
        {
            RaC.CC.enabled = false;
            player.transform.position = RaC.pos3.transform.position;
            RaC.CC.enabled = true;
        }



        else
        {
            RaC.CC.enabled = false;
            player.transform.position = RaC.pos1.transform.position;
            RaC.CC.enabled = true;
        }

    }
    public void SaveGameStatus()
    {
       cp.SaveFromSceneToManager();
        string gameStatusJson = JsonUtility.ToJson(gameStatus);
        File.WriteAllText(filePath + "/" + FILE_NAME, gameStatusJson);
        Debug.Log("File created and saved");
       // cp.SaveFromSceneToManager();
       // Debug.Log(gameStatus.health);

    }
    public void LoadGameStatus()
    {
        if (File.Exists(filePath + "/" + FILE_NAME))
        {
            string loadedJson = File.ReadAllText(filePath + "/" + FILE_NAME);
            gameStatus = JsonUtility.FromJson<GameStatus>(loadedJson);
            Debug.Log("File loaded successfully");
            Respawn();

        }
        else
        {
            resetGame();
            Debug.Log("File not found");
        }

        if (gameStatus.enemyCount >= 1)
        {
            enemy1.gameObject.SetActive(false);
        }

        if (gameStatus.enemyCount >= 2)
        {
            enemy2.gameObject.SetActive(false);
        }
        if (gameStatus.enemyCount >= 3)
        {
            enemy3.gameObject.SetActive(false);
        }

        if (gameStatus.enemyCount >= 4)
        {
            enemy4.gameObject.SetActive(false);
        }

        if (gameStatus.enemyCount >= 5)
        {
            enemy5.gameObject.SetActive(false);
        }
        if (gameStatus.enemyCount >= 6)
        {
            enemy6.gameObject.SetActive(false);
        }

    }



    public void Start()
    {
        filePath = Application.persistentDataPath;
        gameStatus = new GameStatus();
        Debug.Log(filePath);
        LoadGameStatus();
    }

    public void Finish()
    {
        if (gameStatus.score > gameStatus.highscore)
        {
            gameStatus.highscore = gameStatus.score;
            newHighscore.SetActive(true);
        }
        
        //  gameStatus.highscore = gameStatus.score;

        //resetGame();
    }
    public void resetGame()
    {
       gameStatus.Coins.Clear();
        // gameStatus.playerName = "Keith";
        gameStatus.spawnPoint = RaC.checkpointCount = 0;
        gameStatus.health = mystats.maxHealth;
        gameStatus.score = 0;
        gameStatus.Coins = new  List<Vector3>(){  new Vector3(0,1,8),
                                                 new Vector3(0,1,104),
                                                 new Vector3(0,1,121),
                                                 new Vector3(84,1,148),
                                                 new Vector3(87,1,187),
                                                 new Vector3(88,1,202),
                                                 new Vector3(88,1,216),
                                                 new Vector3(88,1,231),
                                                 new Vector3(84,1,247),
                                                 new Vector3(174,1,266),
                                            };
         gameStatus.redActive=false;
   gameStatus.BlueActive=false;
    gameStatus.RedLight=false;
    gameStatus.BlueLight=false;
        gameStatus.Gemcollected = false;
        gameStatus.enemyCount = 0;
    //gameStatus.highscore = 0;
    //  gameStatus.coins = 0;
    //  gameStatus.checkpoint1 = true;
    //gameStatus.slider=
    string gameStatusJson = JsonUtility.ToJson(gameStatus);
        File.WriteAllText(filePath + "/" + FILE_NAME, gameStatusJson);
        Debug.Log("File created and saved");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //  cp.SaveFromSceneToManager();
    }

    // Update is called once per frame


    public void DeathCount()
    { 
        if(platformCount<=gameStatus.enemyCount)
        {
            Platform.SetActive(true);
        }
    }

    public void GameOver()
    {
       // score.SetActive(false);
        GameOverscreen.SetActive(true);
        // score.SetActive(false);
        FindObjectOfType<audioManager>().StopPlaying("Theme");
        
        Destroy(enemy1);
        Destroy(enemy2);
        Destroy(enemy3);
        Destroy(enemy4);
        Destroy(enemy5);
        Destroy(enemy6);
        if (gameStatus.score > gameStatus.highscore)
        {
            gameStatus.highscore = gameStatus.score;
            newhighscoreGameOver.SetActive(true);
        }
    }

}


   

