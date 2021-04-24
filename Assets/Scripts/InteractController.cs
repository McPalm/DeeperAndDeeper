using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public Camera Camera;
    public float maxDistance = 2f;

    public void Interact()
    {
        RaycastHit info;
        var hit = Physics.Raycast(origin: Camera.transform.position, direction: Camera.transform.forward, hitInfo: out info);
        if(hit)
        {
            if(info.distance < 2f)
            {
                var target = info.collider.GetComponent<IInteractable>();
                if (target != null)
                    target.Interact();
            }
        }
    }
}
