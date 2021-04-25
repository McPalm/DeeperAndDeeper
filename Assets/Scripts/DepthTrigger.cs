using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthTrigger : MonoBehaviour
{
    public float Depth;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<FirstPersonPlayer>();
        if (player)
        {
            FindObjectOfType<DynamicWater>().SetDepth(Depth);
            gameObject.SetActive(false);
        }
    }
    
}
