using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumpadManager : MonoBehaviour
{
    public Text DisplayText;

    public DoorSwitch doorSwitch;

    public string Default = "....";

    public string Incorrect = "xxxx";

    public string Correct = "oooo";

    public string Code = "0000";

    public string current = "";
    int Entries = 0;
    int LookingEntries = 4;

    bool Complete = false;


    public void InputGiven(string input)
    {
        if (Complete) return;

        Entries++;
        current = current + input;
        if (Entries >= LookingEntries)
        {
            if(current == Code)
            {
                DisplayText.text = Correct;

                doorSwitch.Interact();
                Complete = true;
                return;
            }


            current = "";
            DisplayText.text = Default;
            Entries = 0;
            return;
        }

        DisplayText.text = current;
    }
}
