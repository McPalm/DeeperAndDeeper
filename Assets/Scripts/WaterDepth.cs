using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDepth : MonoBehaviour
{
    public Transform head;
    FirstPersonPlayer Player;

    public LayerMask waterMask;
    public LayerMask groundMask;

    public bool InWater => distanceToWater < distanceToGround;
    public float Depth => distanceToGround - distanceToWater;
    float distanceToWater;
    float distanceToGround;
    float maxSpeed;

    void Start()
    {
        Player = GetComponent<FirstPersonPlayer>();
        maxSpeed = Player.runspeed;
    }

    void FixedUpdate()
    {
        RaycastHit info;
        var hit = Physics.Raycast(origin: head.position, direction: Vector3.down, hitInfo: out info, layerMask: waterMask, maxDistance: 2f);
        if (hit)
        {
            distanceToWater = info.distance;
        }
        else
            distanceToWater = 2f;

        hit = Physics.Raycast(origin: head.position, direction: Vector3.down, hitInfo: out info, layerMask: groundMask, maxDistance: 2.1f);
        if (hit)
        {
            distanceToGround = info.distance;
        }
        else
            distanceToGround = 2.1f;

        if(InWater)
        {
            Player.runspeed = maxSpeed * Mathf.Max(1f - Depth * .75f, .2f);
        }
        else
            Player.runspeed = maxSpeed;
    }
}
