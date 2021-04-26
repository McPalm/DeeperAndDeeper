using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelPump : MonoBehaviour, IInteractable
{

    public UnityEvent FlipSwitch;

    public FuelPuzzle Manager;

    public bool Open = true;
    public GameObject Pivot;



    public void Interact()
    {
        if (!Open) return;

        Pivot.transform.Rotate(0, 90, 0);

        Manager.SwitchFlipped();

        Open = false;
    }

}
