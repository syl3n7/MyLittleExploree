using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject panel;
    Scene sCene;

    private int counteR;
    public Text RetriesText;

    public GameObject toggle;

    public Transform p;

    private Vector3 reset;

    void Start()
    {
        reset = p.transform.position;
        Application.targetFrameRate = 60; //limit fps to 60
        Cursor.visible = true;
        sCene = SceneManager.GetActiveScene();
        if (sCene.name != "Credits" && sCene.name != "HighScore" && sCene.name != "Instructions" && sCene.name != "MainMenu" && sCene.name != "Options" && sCene.name != "PlayerChoice" && sCene.name != "PlayerCustomizer") panel.SetActive(false);
    }
    void Update()
    {
        //implementation of "R" Reload current scene - common feature of platformer games.
        if (sCene.name != "Credits" && sCene.name != "HighScore" && sCene.name != "Instructions" && sCene.name != "MainMenu" && sCene.name != "Options" && sCene.name != "PlayerChoice" && sCene.name != "PlayerCustomizer")
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                RetriesText.text = "Retries: " + ++counteR;
                p.transform.position = reset;
            }
        }
        //end of implementation of "R".
        if (sCene.name != "1Player" || sCene.name != "2Players") Cursor.visible = true;
        else Cursor.visible = false;
        if (sCene.name != "Credits" && sCene.name != "HighScore" && sCene.name != "Instructions" && sCene.name != "MainMenu" && sCene.name != "Options" && sCene.name != "PlayerChoice" && sCene.name != "PlayerCustomizer") pauseMenu();
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

    public void AudioControl(bool muted){ //controlar audio
        if (muted)
        {
            AudioListener.volume = 0f;
            Debug.Log("Muted");
        }
        else
        {
            AudioListener.volume = 0.4f;
            Debug.Log("UnMuted");
        }
    }

    
}
