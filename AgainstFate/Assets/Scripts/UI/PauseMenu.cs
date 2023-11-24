using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject dialog;
    //private bool GameIsPaused = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        //GameIsPaused = true;
        pauseButton.SetActive(false);
        Time.timeScale = 0;
       dialog.SetActive(false);
        
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        //GameIsPaused = false;
        Time.timeScale = 1;
        dialog.SetActive(true);

    }
    
}
