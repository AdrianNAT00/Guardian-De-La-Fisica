using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float gravity;
    private float[] lanePositions = { -10f, 0f, 10f }; // Adjust these values based on your scene
    private int currentLane = 1; // Start in the center lane
    public float laneSwitchSpeed = 10f;
    private bool isGrounded;
    private Vector3 velocity;      // Stores velocity, including jump velocity and gravity

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Set the initial position of the player
        Vector3 startPosition = new Vector3(lanePositions[1], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * laneSwitchSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;
        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Slight downward force to keep the player grounded
        }
        if (isGrounded && !GameManager.Instance.GameOver && Input.GetKeyDown("space"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity
        characterController.Move(velocity * Time.deltaTime);
        // Check for input to change lanes
        if (!GameManager.Instance.GameOver && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (!GameManager.Instance.GameOver && Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        // Smoothly move the player to the target lane position
        Vector3 targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneSwitchSpeed);
    }
    void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
        }
    }

    void MoveRight()
    {
        if (currentLane < lanePositions.Length - 1)
        {
            currentLane++;
        }
    }
}
