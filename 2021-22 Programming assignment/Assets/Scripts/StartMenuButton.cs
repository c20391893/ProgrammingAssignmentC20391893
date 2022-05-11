using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuButton : MonoBehaviour
{
    // Start is called before the first frame update

    //private GameManager gm;
   // public Text highScore;

    public void Start()
    {
      //  gm = GameManager.Instance;
    }

    public void Update()
    {
      //  highScore.text = "Highscore: " + gm.gameStatus.highscore + "\n";
    }
    // Update is called once per frame
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
