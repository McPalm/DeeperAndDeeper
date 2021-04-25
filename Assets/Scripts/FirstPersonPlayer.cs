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

    float walkTime = 0f;
    Vector3 CameraRoot;
    public event System.Action OnJump;
    public event System.Action OnStep;
    public event System.Action OnLand;

    void Start()
    {
        CameraRoot = playerCamera.transform.localPosition;
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Move == Vector2.zero)
            walkTime = 0f;
        else
            walkTime += Crouch ? Time.fixedDeltaTime * crouchSpeed : Time.fixedDeltaTime * runspeed;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        var speed = IsCrouching ? crouchSpeed : runspeed;
        float curSpeedx = speed * Move.y;
        float curSpeedy = speed * Move.x;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedx) + (right * curSpeedy);
        moveDirection.y = movementDirectionY;

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }
        else
        {
            if(moveDirection.y < -1f)
            {
                OnLand?.Invoke();
                moveDirection.y = -0.1f;
            }
        }

        characterController.Move(moveDirection * Time.fixedDeltaTime);

        if(Crouch != IsCrouching)
        {
            IsCrouching = Crouch;
            characterController.height = Crouch ? .95f : 1.7f;
        }
    }

    public void Jump()
    {
        if(characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            OnJump?.Invoke();
        }

    }

    bool down = false;
    private void Update()
    {
        float osett = Mathf.Sin(walkTime * 3f);
        playerCamera.transform.localPosition = CameraRoot + Vector3.up * osett * Mathf.Clamp(walkTime, 0f, .2f) * .35f;
        if (osett > .5f)
        {
            if(down == false)
            {
                down = true;
                if (characterController.isGrounded)
                    OnStep?.Invoke();
            }
        }
        else
            down = false;
    }

    public void Look(Vector2 change)
    {
        rotationX += -change.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, change.x * lookSpeed, 0);
    }
}
