using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractPickup : MonoBehaviour, IInteractable
{
    public UnityEvent OnPickup;

    public void Interact()
    {
        OnPickup.Invoke();
        gameObject.SetActive(false);
    }


}
