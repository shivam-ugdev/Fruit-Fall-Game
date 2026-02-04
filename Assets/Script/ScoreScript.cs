using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public static int scorePoint = 0;

    [SerializeField]private Text hiscore;
    public static int hiScoreCount;

    private Text score;

    void Start()
    {
        scorePoint = 0;
        // Find and assign Text components
        score = GetComponent<Text>();
        hiscore = GameObject.Find("HiScoreText").GetComponent<Text>(); // Ensure the HiScoreText object exists in the scene

        // Retrieve high score from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            hiScoreCount = 0;
        }
    }

    void Update()
    {
        // Update the high score if the current score exceeds it
        if (scorePoint > hiScoreCount)
        {
            hiScoreCount = scorePoint;
            PlayerPrefs.SetInt("HighScore", hiScoreCount);
        }

        // Update the score and high score UI texts
        score.text = "Score: " + scorePoint.ToString();
        hiscore.text = "Hi_Score: " + hiScoreCount.ToString();
    }
}
