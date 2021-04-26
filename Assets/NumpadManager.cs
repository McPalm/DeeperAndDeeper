using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumpadManager : MonoBehaviour
{
    public TextMesh DisplayText;

    public DoorSwitch doorSwitch;

    public string Default = "....";

    public string Incorrect = "xxxx";

    public string Correct = "oooo";

    public string Code = "0000";

    public string current = "";
    int Entries = 0;
    int LookingEntries = 4;



    public void InputGiven(string input)
    {
        Entries++;
        current = current + input;
        if (Entries >= LookingEntries)
        {
            if(current == Code)
            {
                DisplayText.text = Correct;

                doorSwitch.Interact();
                DisplayText.gameObject.SetActive(false);
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
