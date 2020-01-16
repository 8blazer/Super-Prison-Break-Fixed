using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("Opening");
    }
    public void Restart() //Skips the opening cutscene;
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
