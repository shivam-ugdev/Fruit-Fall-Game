using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        audioSource.Play();
    }
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("OnClick");
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("OnClick");
        Application.Quit();
        Debug.Log("quitgame");
    }
}
