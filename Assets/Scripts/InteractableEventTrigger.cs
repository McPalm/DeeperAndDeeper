using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEventTrigger : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteractEvent;

    public void Interact()
    {
        OnInteractEvent.Invoke();
    }
}
