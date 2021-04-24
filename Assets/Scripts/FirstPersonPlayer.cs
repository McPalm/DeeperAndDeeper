using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public float runspeed = 10;
    public float crouchSpeed = 5f;
    public float jumpSpeed = 8;
    public float gravity = 20f;
    public Camera playerCamera;

    public float lookSpeed = 2;
    public float lookXLimit = 45;

    public float crouchDistance = 0.25f;

    CharacterController characterController;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public Vector2 Move { get; set; }
    public bool Crouch { get; set; }

    bool IsCrouching = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        var speed = characterController.height < 1f ? crouchSpeed : runspeed;
        float curSpeedx = speed * Move.y;
        float curSpeedy = speed * Move.x;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedx) + (right * curSpeedy);
        moveDirection.y = movementDirectionY;

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }

        characterController.Move(moveDirection * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        Debug.Log("Jump");
        Debug.Log(characterController.isGrounded);
        if(characterController.isGrounded)
            moveDirection.y = jumpSpeed;

    }

    private void Update()
    {
        if(Crouch != IsCrouching)
        {
            IsCrouching = Crouch;
            characterController.height = Crouch ? .95f : 1.6f;
        }

        /*
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        */
    }

    public void Look(Vector2 change)
    {
        rotationX += -change.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, change.x * lookSpeed, 0);
    }
}
