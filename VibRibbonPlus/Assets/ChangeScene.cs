using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    GameObject Discord;
    public int RenderDistance;
    public void Start()
    {
        Discord = GameObject.Find("Discord");
        if(SceneManager.sceneCount == 1)
        StartGame();
        RenderDistance = PlayerPrefs.GetInt("Render", 20);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
        Discord.GetComponent<DiscordManager>().Menu = true;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Editor");
        Discord.GetComponent<DiscordManager>().Menu = true;
    }

    public void OpenEditor()
    {
        SceneManager.LoadScene("Editor", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Main Menu");
        Discord.GetComponent<DiscordManager>().Menu = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
