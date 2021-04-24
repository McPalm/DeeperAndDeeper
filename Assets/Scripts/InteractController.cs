using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    public Camera Camera;
    public float maxDistance = 2f;

    public Sprite StandardCrosshair;
    public Sprite ActiveCrosshair;

    public UnityEngine.UI.Image UIImage;

    public void LateUpdate()
    {
        RaycastHit info;
        var hit = Physics.Raycast(origin: Camera.transform.position, direction: Camera.transform.forward, hitInfo: out info);
        if (hit)
        {
            if (info.distance < 2f)
            {
                var target = info.collider.GetComponent<IInteractable>();
                SetCrosshair(target != null);
            }
            else
                SetCrosshair(false);
        }
        else
            SetCrosshair(false);
    }

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

    void SetCrosshair(bool active)
    {
        UIImage.sprite = active ? ActiveCrosshair : StandardCrosshair;
    }
}
