using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Using Unity's new input system

public class PlayerMvmnt : MonoBehaviour
{

    [Header("Movement Settings")]
    public float laneSwitchSpeed = 8f;
    public float jumpForce = 5f;

    [Header("Lane Settings")]
    public float laneDistance = 3f;  // Distance between lanes
    private int targetLane = 1; // Start in the middle lane (0 = left, 1 = middle, 2 = right)

    private Rigidbody rb;
    private bool isGrounded;

    [Header("Jump Settings")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance = 0.2f;

    [Header("Jump Settings")]
    public Animator animator;
    GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        // Move the ground backward
        transform.position += Vector3.forward * gameManager.playerSpeed * Time.deltaTime; // PlayerSpeed is Controlled by Game Manager

        // Check for jump input
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }

        // Lane movement (A/D or left/right arrows)
        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            MoveLane(false); // Move left
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            MoveLane(true); // Move right
        }

        // Smooth transition to the target lane
        Vector3 targetPosition = transform.position;
        targetPosition.x = Mathf.Lerp(targetPosition.x, targetLane * laneDistance - laneDistance, Time.deltaTime * laneSwitchSpeed);
        transform.position = targetPosition;

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void MoveLane(bool goingRight)
    {
        // Move to the next lane if within bounds
        if (goingRight)
        {
            targetLane = Mathf.Min(targetLane + 1, 2);
        }
        else
        {
            targetLane = Mathf.Max(targetLane - 1, 0);
        }
    }
}