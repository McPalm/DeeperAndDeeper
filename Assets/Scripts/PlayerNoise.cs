using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    public AudioClip step;
    public AudioClip waterStep;
    public AudioClip waterThread;
    public AudioClip jump;
    WaterDepth WaterDepth;

    AudioSource AudioSource => audioSources[count++ % audioSources.Length];
    public AudioSource[] audioSources;
    int count = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        var player = GetComponent<FirstPersonPlayer>();
        player.OnJump += Player_OnJump;
        player.OnLand += Player_OnLand;
        player.OnStep += Player_OnStep;
        WaterDepth = GetComponent<WaterDepth>();
    }

    private void Player_OnStep()
    {
        Step();
        // AudioSource.PlayClipAtPoint(WaterDepth.InWater ? waterStep : step, transform.position);
    }

    private void Player_OnLand()
    {
        Step();
        // AudioSource.PlayClipAtPoint(WaterDepth.InWater ? waterStep : step, transform.position);
    }

    private void Player_OnJump()
    {
        Step();
        // AudioSource.PlayClipAtPoint(jump, transform.position);
    }

    void Step()
    {
        float water = WaterDepth.Depth;
        if (WaterDepth.InWater)
        {
            var depth = WaterDepth.Depth;
            if (depth < .2f)
                PlayNoise(waterStep, transform.position, .9f + .2f * Random.value, 1f);
            else if (depth > 1f)
                PlayNoise(waterThread, transform.position, .9f + .2f * Random.value, 1f);
            else
            {
                depth = (depth - .2f) / .8f;
                PlayNoise(waterStep, transform.position, .9f + .2f * Random.value, 1f - depth);
                PlayNoise(waterThread, transform.position, .9f + .2f * Random.value, depth);
            }

        }
        else
        {
            PlayNoise(step, transform.position, .9f + .2f * Random.value, 1f);
        }
    }

    void PlayNoise(AudioClip audioClip, Vector3 position, float pitch = 1f, float volume = 1f)
    {
        var source = AudioSource;
        source.transform.position = position;
        source.clip = audioClip;
        source.volume = volume * volume;
        source.pitch = pitch;
        source.Play();
    }
}
