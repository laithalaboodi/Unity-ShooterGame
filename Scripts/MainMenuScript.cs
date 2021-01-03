using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public Button resumeButton;

    void Awake()
    {
        //always makes the pause menu invisable 
        pauseMenu.SetActive(false);
        resumeButton.onClick.AddListener(OnResumePressed);

    }


    public void PlayGame()
    {
        // specifc secen:   SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayCredit()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumePressed()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
       
    }
}
