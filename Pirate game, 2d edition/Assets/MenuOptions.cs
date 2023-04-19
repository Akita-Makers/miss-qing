using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Sailing part");
    }
    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}