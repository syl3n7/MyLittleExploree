using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject panel;
    Scene sCene;
    void Start()
    {
        Application.targetFrameRate = 60; //limit fps to 60
        sCene = SceneManager.GetActiveScene();
        if (sCene.name != "MainMenu") panel.SetActive(false);
    }
    void Update()
    {
        if (sCene.name != "Menu") pauseMenu();
    }
    void pauseMenu() //controlar o menu de pausa em todas as scenes exceto main menu
    {
        if (Input.GetKeyUp(KeyCode.Escape)) panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
    public void LoadScene(string sceneName) //serve para carregar as scenes
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() //serve para terminar o processo onde o jogo e executado
    {
        Application.Quit();
    }
}
