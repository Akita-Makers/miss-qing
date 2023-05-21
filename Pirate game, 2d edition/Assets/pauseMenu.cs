using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI;

    private void Start() {
        pauseMenuUI.SetActive(isPaused);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }
    public void restart()
    {
        togglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void returnToMenu()
    {
        togglePause();
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void togglePause()
    {
        if(!isPaused){
            isPaused = true;
            Time.timeScale = 0;
            
        }
        else{
            isPaused = false;
            Time.timeScale = 1;
        }
        pauseMenuUI.SetActive(isPaused);
    }
}
