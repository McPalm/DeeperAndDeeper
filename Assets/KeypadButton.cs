using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypadButton : MonoBehaviour, IInteractable
{
    public UnityEvent Pressed;

    public NumpadManager Manager;

    public string Num = "0";

    public void Interact()
    {
        Manager.InputGiven(Num);
    }
}
