using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    //private bool GameIsPaused = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        //GameIsPaused = true;
        pauseButton.SetActive(false);
        Time.timeScale = 0;
        
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
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
       
    }
    
}
