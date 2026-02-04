using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private Text finalScoreText;  // Add a reference for the final score Text UI

    private void Start()
    {
        tryAgainButton.SetActive(false);
        finalScoreText.gameObject.SetActive(false);  // Hide the final score text initially
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fruit" || collision.tag == "endGame")
        {
            // Stop the game
            Time.timeScale = 0;

            FindObjectOfType<AudioManager>().Play("GameOver");


            // Display the final score and try again button
            if (tryAgainButton != null)
            {
                tryAgainButton.SetActive(true);
            }

            if (finalScoreText != null)
            {
                finalScoreText.gameObject.SetActive(true);  // Show the final score text
                finalScoreText.text = "Final Score: " + ScoreScript.scorePoint.ToString();  // Set the final score
            }
        }
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("OnClick");
        Time.timeScale = 1;  // Resume the game time
        SceneManager.LoadScene("GameScene");  // Reload the game scene
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("OnClick");
        Time.timeScale = 1;  // Resume the game time
        SceneManager.LoadScene("Main_Menu");  // Load the main menu scene
    }
}
