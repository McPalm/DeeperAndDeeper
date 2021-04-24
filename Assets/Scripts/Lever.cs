using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public Transform LeverRoot;

    string d = "";

    public void SetDirection(string dir)
    {
        float to = 0f;
        switch (dir)
        {
            case "up":
                StartCoroutine(Lerp(90f));
                break;
            case "down":
                StartCoroutine(Lerp(270f));
                break;
        }
    }

    public IEnumerator Lerp(float to)
    {
        float from = LeverRoot.localEulerAngles.z;

        for (float f = 0; f < 1f; f += Time.deltaTime)
        {
            LeverRoot.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(from, to, f));
                yield return null;
        }
        LeverRoot.localEulerAngles = new Vector3(0f, 0f, to);
    }

    public void Interact()
    {
        StopAllCoroutines();
        d = d == "up" ? "down" : "up";
        SetDirection(d);
    }
}
