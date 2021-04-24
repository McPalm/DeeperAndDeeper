using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour, IInteractable
{
    public bool Open;
    public Animator Door;
    public Collider Collider;

    public void Interact()
    {
        Open = !Open;
        Door.SetBool("Open", Open);
        Collider.enabled = !Open;
    }

    // Start is called before the first frame update
    void Start()
    {
        Door.SetBool("Open", Open);
        Collider.enabled = !Open;
    }   
}
