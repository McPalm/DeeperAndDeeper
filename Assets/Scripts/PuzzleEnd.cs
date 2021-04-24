using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnd : MonoBehaviour
{
    public GameObject[] WhenActive;
    public GameObject[] WhenInactive;

    public void SetActive(bool active)
    {
        foreach(var a in WhenActive)
        {
            Set(a, active);
        }
        foreach (var a in WhenInactive)
        {
            Set(a, !active);
        }
    }

    void Set(GameObject o, bool active)
    {
        var light = o.GetComponent<Light>();
        if (light)
            light.enabled = active;
        var doorSwitch = o.GetComponent<DoorSwitch>();
        if (doorSwitch)
            doorSwitch.enabled = active;
    }
}
