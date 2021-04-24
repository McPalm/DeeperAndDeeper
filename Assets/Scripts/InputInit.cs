using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInit : MonoBehaviour
{
    FirstPersonPlayer FirstPersonPlayer;


    // Start is called before the first frame update
    void Start()
    {
        FirstPersonPlayer = GetComponent<FirstPersonPlayer>();
        var input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        if (input.isActiveAndEnabled)
        {
            foreach (var action in input.currentActionMap.actions)
            {
                switch (action.name)
                {
                    case "Move":
                        action.performed += (a) => FirstPersonPlayer.Move = a.ReadValue<Vector2>();
                        action.started += (a) => FirstPersonPlayer.Move = a.ReadValue<Vector2>();
                        action.canceled += (a) => FirstPersonPlayer.Move = a.ReadValue<Vector2>();
                        break;
                    case "Crouch":
                        action.started += (a) => FirstPersonPlayer.Crouch = true;
                        action.canceled += (a) => FirstPersonPlayer.Crouch = false;
                        break;
                    case "Jump":
                        action.started += (a) => FirstPersonPlayer.Jump();
                        break;
                    case "Look":
                        action.started += Look;
                        action.performed += Look;
                        action.canceled += Look;
                        break;

                }
            }
        }
    }



    private void Look(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        look = obj.ReadValue<Vector2>();
        joystick = !(obj.control.name == "delta");
    }

    bool joystick = false;
    Vector2 look;
    Vector2 drag;
    private void FixedUpdate()
    {
        if (joystick && look != Vector2.zero)
        {
            drag = drag * .94f + look * .06f;
            FirstPersonPlayer.Look(drag);
        }
        else
        {
            drag = Vector2.zero;
            FirstPersonPlayer.Look(look);
        }
        
    }
}
