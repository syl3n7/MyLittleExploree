using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;

    private float elapsedTime;
    private TimeSpan timePlaying;
    Scene sCene;

    void Start()
    {
        sCene = SceneManager.GetActiveScene();
        timer.text = "00:00:00";
    }

    void Update()
    {
        if (sCene.name == "1Player")
        {
            elapsedTime += 1 * Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timer.text = timePlayingStr; 
        }
    }
}
