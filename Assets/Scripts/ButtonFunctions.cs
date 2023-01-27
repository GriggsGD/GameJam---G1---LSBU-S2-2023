using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void LoadMenu(int _scene)
    {
        GameManager.instance.LoadMenu();
    }
    public void StartGame()
    {
        GameManager.instance.StartGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowCredits()
    {
        SceneManager.LoadScene(3);
    }
}
