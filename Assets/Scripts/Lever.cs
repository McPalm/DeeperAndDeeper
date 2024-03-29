using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public bool startUp = false;

    public Transform LeverRoot;

    string d = "";

    public GameObject Up;
    public GameObject Down;

    public AudioClip Noise;

    void Start()
    {
        d = startUp ? "up" : "down";
        SetDirection(d);
    }


    public void SetDirection(string dir)
    {
        switch (dir)
        {
            case "up":
                StartCoroutine(Lerp(90f, true));
                break;
            case "down":
                StartCoroutine(Lerp(270f, false));
                break;
        }
    }

    public IEnumerator Lerp(float to, bool up)
    {
        Set(Up, false);
        Set(Down, false);
        float from = LeverRoot.localEulerAngles.z;

        for (float f = 0; f < 1f; f += Time.deltaTime)
        {
            LeverRoot.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(from, to, f));
                yield return null;
        }
        LeverRoot.localEulerAngles = new Vector3(0f, 0f, to);
        Set(Up, up);
        Set(Down, !up);
    }

    public void Interact()
    {
        StopAllCoroutines();
        d = d == "up" ? "down" : "up";
        SetDirection(d);
        AudioSource.PlayClipAtPoint(Noise, transform.position);
    }

    void Set(GameObject o, bool on)
    {
        var ps = o.GetComponent<ParticleSystem>();
        if(ps)
        {
            if (on)
                ps.Play();
            else
                ps.Stop();
        }
        var light = o.GetComponent<Light>();
        if (light)
            light.enabled = on;
        var end = o.GetComponent<PuzzleEnd>();
        if(end)
            end.SetActive(on);
        var audio = o.GetComponent<AudioSource>();
        if (audio)
            audio.enabled = on;
    }
}
