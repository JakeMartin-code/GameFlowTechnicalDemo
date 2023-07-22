using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject playButton;
    public GameObject title;
    public TextMeshProUGUI scoreText;
    public HighScoreManager highScoreManager;
    public GameObject inputField;
 // /  public TextMeshProUGUI highScoreText;
  //  public TextMeshProUGUI highScoreText2;
    //public TextMeshProUGUI highScoreText3;
    public GameObject player;
    public bool hasDied;

    public static int score;
    public bool scoreIncreased = false;

    //private int firstPlace;
    //private int secondPlace;
    //private int thirdPlace;
    

    void Start()
    {
        SetUp();
      //  highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();

       // Debug.Log(PlayerPrefs.GetInt("Highscore"));
    }

    void SetUp()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        title.SetActive(true);
        playButton.SetActive(true);
      
    }

    public void StartGame()
    {

        if(hasDied)
        {
            score = 0;
            SceneManager.LoadScene(0);
            
        }
        else
        {
            hasDied = false;
            player.SetActive(true);
            playButton.SetActive(false);
            title.SetActive(false);
            gameOver.SetActive(false);
            inputField.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        inputField.SetActive(true);
        hasDied = true;
        Time.timeScale = 0f;
        highScoreManager.AddHighScore(score);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        //scoreIncreased = true;

      //  if (score > PlayerPrefs.GetInt("Highscore", 0))
      //  {
       //     PlayerPrefs.SetInt("Highscore", score);
        //    //highScoreText.text = "Highscore: " + score.ToString();
       // }
    }

    public void DebugHighscore()
    {
        //PlayerPrefs.DeleteAll();
       // highScoreText.text = "Highscore: " + "0";
    }

}
