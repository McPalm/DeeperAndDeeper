using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEventToggle : MonoBehaviour, IInteractable
{
    public UnityEvent OnActivateEvent;
    public UnityEvent OnIDeactivateEvent;

    public bool activated;

    public void Interact()
    {
        activated = !activated;
        if (activated)
            OnActivateEvent.Invoke();
        else
            OnIDeactivateEvent.Invoke();
    }
}
