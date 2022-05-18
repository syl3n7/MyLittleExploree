using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetLevelOnOutOfBounds : MonoBehaviour
{
    Scene sCene;
    void Start()
    {
        sCene = SceneManager.GetActiveScene();
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(sCene.name); //reload current scene
    }
}
