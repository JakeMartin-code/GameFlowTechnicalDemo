using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public InputField initialsInputField;
    public TextMeshProUGUI highScoreText;
    public  int NUM_TOP_SCORES = 3;
    public int lowestScore;
    public string lowestScoreKey;
    public string highScoreKey;
    public int maxCharacters = 10;

    /*
    private void Start()
    {
        // Load the high scores from PlayerPrefs
        List<HighScoreEntry> highScores = new List<HighScoreEntry>();
        for (int i = 0; i < NUM_TOP_SCORES; i++)
        {
            string initials = PlayerPrefs.GetString("Initials" + i.ToString(), "");
            int score = PlayerPrefs.GetInt("Score" + i.ToString(), 0);
            if (!string.IsNullOrEmpty(initials) && score > 0)
            {
                highScores.Add(new HighScoreEntry(initials, score));
            }
        }

        // Sort the high scores in descending order
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // Display the high scores in the UI
        highScoreText.text = "";
        for (int i = 0; i < Mathf.Min(highScores.Count, NUM_TOP_SCORES); i++)
        {
            highScoreText.text += highScores[i].initials + ": " + highScores[i].score.ToString() + "\n";
        }
    }
    */
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        // Retrieve and display high scores from PlayerPrefs
        List<HighScoreEntry> highScores = new List<HighScoreEntry>();
        string highScoreString = "";
        for (int i = 0; i < NUM_TOP_SCORES; i++)
        {
            string initials = PlayerPrefs.GetString("Initials" + i.ToString());
            int score = PlayerPrefs.GetInt("Score" + i.ToString());
            highScoreString += (i + 1) + ". " + initials + " - " + score + "\n";
        }
        highScoreText.text = highScoreString;

        // Retrieve and display the lowest score from PlayerPrefs
        int lowestScore = PlayerPrefs.GetInt(lowestScoreKey);
        Debug.Log("Lowest score: " + lowestScore);
        initialsInputField.characterLimit = maxCharacters;
        //lowestScoreText.text = "Lowest Score: " + lowestScore;
    }



    public void AddHighScore(int score)
    {
        // Prompt the user to enter their initials

        int lowestScore = PlayerPrefs.GetInt(lowestScoreKey);

        if (GameManager.score > lowestScore)
        {

            initialsInputField.gameObject.SetActive(true);
            initialsInputField.text = "Type name and press play button to save ";
            initialsInputField.Select();
            initialsInputField.ActivateInputField();

            // Save the high score if the user enters their initials
            initialsInputField.onEndEdit.AddListener(delegate
            {
                SaveHighScore(initialsInputField.text, score);
                initialsInputField.gameObject.SetActive(false);
            });

        }
        else
        {
            Debug.Log("not high enough score");
        }
    }

    private void SaveHighScore(string initials, int score)
    {
        // Load the high scores from PlayerPrefs
        List<HighScoreEntry> highScores = new List<HighScoreEntry>();
        for (int i = 0; i < NUM_TOP_SCORES; i++)
        {
            string oldInitials = PlayerPrefs.GetString("Initials" + i.ToString(), "");
            int oldScore = PlayerPrefs.GetInt("Score" + i.ToString(), 0);
            if (!string.IsNullOrEmpty(oldInitials) && oldScore > 0)
            {
                highScores.Add(new HighScoreEntry(oldInitials, oldScore));
            }
        }

        // Add the new high score and sort the list in descending order
        highScores.Add(new HighScoreEntry(initials, score));
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // Save the top three high scores to PlayerPrefs
        for (int i = 0; i < Mathf.Min(highScores.Count, NUM_TOP_SCORES); i++)
        {
            PlayerPrefs.SetString("Initials" + i.ToString(), highScores[i].initials);
            PlayerPrefs.SetInt("Score" + i.ToString(), highScores[i].score);
        }
    }

    private class HighScoreEntry
    {
        public string initials;
        public int score;

        public HighScoreEntry(string initials, int score)
        {
            this.initials = initials;
            this.score = score;
        }
    }
}
