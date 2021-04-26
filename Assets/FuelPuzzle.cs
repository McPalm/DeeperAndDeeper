using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelPuzzle : MonoBehaviour
{

    public Text EditableText;

    public int PumpsNeeded = 3;

    public int CurrentPumps = 0;

    public DoorSwitch doorSwitch;

    bool Complete = false;

    public void SwitchFlipped()
    {
        if (Complete) return;

        CurrentPumps++;
        if(CurrentPumps >= PumpsNeeded)
        {
            EditableText.text = "ALL PUMPS ONLINE\n FUEL NOMINAL";
            Complete = true;
            doorSwitch.Interact();
        }

        EditableText.text = ("FUEL PUMPS OFFLINE\n" + CurrentPumps.ToString() + "/3");
    }

}
