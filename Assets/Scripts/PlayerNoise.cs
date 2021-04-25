using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    public AudioClip step;
    public AudioClip waterStep;
    public AudioClip jump;
    WaterDepth WaterDepth;
    

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

        AudioSource.PlayClipAtPoint(WaterDepth.InWater ? waterStep : step, transform.position);

    }

    private void Player_OnLand()
    {
        AudioSource.PlayClipAtPoint(WaterDepth.InWater ? waterStep : step, transform.position);
    }

    private void Player_OnJump()
    {
        AudioSource.PlayClipAtPoint(jump, transform.position);
    }
}
