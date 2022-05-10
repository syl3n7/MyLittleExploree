using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject panel;
    Scene sCene;
    public bool mute;
    void Start()
    {
        Application.targetFrameRate = 60; //limit fps to 60
        Cursor.visible = true;
        sCene = SceneManager.GetActiveScene();
        if (sCene.name != "MainMenu" && sCene.name != "Credits") panel.SetActive(false);
    }
    void Update()
    {
        //implementation of "R" Reload current scene - common feature of platformer games.
        if (sCene.name != "MainMenu" && sCene.name != "Credits") if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(sCene.name);
        //end of implementation of "R".
        if (sCene.name != "1Player" || sCene.name != "2Players") Cursor.visible = true;
        else Cursor.visible = false;
        if (sCene.name != "MainMenu" && sCene.name != "Credits") pauseMenu();
    }
    void pauseMenu() //controlar o menu de pausa em todas as scenes exceto main menu
    {
        if (Input.GetKeyUp(KeyCode.Escape)) panel.SetActive(!panel.activeSelf);

        if (panel.activeSelf) {
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else {
            Cursor.visible = false;
            Time.timeScale = 1f; 
        }
    }
    public void LoadScene(string sceneName) //serve para carregar as scenes
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() //serve para terminar o processo onde o jogo e executado
    {
        Application.Quit();
    }

    public void AudioControl()
    {
        //if (mute)
        //{
            AudioListener.volume = 0f;
        //}
        //else
        //{
        //    mute = false;
        //    AudioListener.volume = 1f;
        // }
    }
}
