using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{

    public float speed = 10;
    public float jumpSpeed = 8;
    public float gravity = 20f;
    public Camera playerCamera;

    public float lookSpeed = 2;
    public float lookXLimit = 45;

    public float crouchDistance = 0.25f;

    CharacterController characterController;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

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

        float curSpeedx = speed * Input.GetAxis("Vertical");
        float curSpeedy = speed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedx) + (right * curSpeedy);

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }




        characterController.Move(moveDirection * Time.fixedDeltaTime);


    }

    private void Update()
    {


        if (Input.GetButtonDown("Crouch"))
        {
            characterController.height = 1;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            characterController.height = 1.5f;
        }


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
