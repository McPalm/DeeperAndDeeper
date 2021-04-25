using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThem : MonoBehaviour
{
    public Transform Checkpoint;
    public AudioClip DeathNoise;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CharacterController>();
        if (player)
        {
            player.enabled = false;
            player.transform.position = Checkpoint.position;
            player.enabled = true;
            AudioSource.PlayClipAtPoint(DeathNoise, other.transform.position);
        }
    }
}
