using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    public GameObject Stone;
    private bool animStone;
    
    public void OpenDoor()
    {
        animStone = true;
        Stone.GetComponent<Animator>().SetBool("Stopped", animStone);
    }

    public void CloseDoor()
    {
        animStone = false;
        Stone.GetComponent<Animator>().SetBool("Stopped", animStone);
    }
}
