using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public GameObject toggle;
    public void AudioControl(bool muted)
    { //controlar audio
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
