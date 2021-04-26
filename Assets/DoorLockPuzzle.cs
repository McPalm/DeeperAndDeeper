using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockPuzzle : MonoBehaviour
{

    public GameObject[] Light;

    public int PumpsNeeded = 3;

    public int CurrentPumps = 0;

    public DoorSwitch doorSwitch;

    bool Complete = false;

    public void Start()
    {
        foreach (GameObject L in Light) L.SetActive(false);
    }

    public void SwitchFlipped()
    {
        if (Complete) return;

        CurrentPumps++;
        if (CurrentPumps >= PumpsNeeded)
        {

            Complete = true;
            doorSwitch.Interact();
        }


        Light[CurrentPumps-1].SetActive(true);

    }

}
