using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;

    private int counteR;
    public Text RetriesText;
    public Transform p;
    private Vector3 reset;

    private float elapsedTime;
    private TimeSpan timePlaying;
    Scene sCene;

    void Start()
    {
        
        reset = p.transform.position;
        sCene = SceneManager.GetActiveScene();
        timer.text = "00:00:00";
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
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyUp(KeyCode.R)) // I've decided to leave left alt as continuous and R as only Up to prevent shit from hitting the fan.
            {
                SceneManager.LoadScene(sCene.name);
            }
        }
        if (sCene.name == "1Player" || sCene.name == "2Players")
        {
            elapsedTime += 1 * Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timer.text = timePlayingStr;
        }
    }
    void SpentPlayingTimer()
    {
        elapsedTime += 1 * Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timePlayingStr = "Wasted Time: " + timePlaying.ToString("mm':'ss'.'ff");
        timer.text = timePlayingStr;
    }

}
