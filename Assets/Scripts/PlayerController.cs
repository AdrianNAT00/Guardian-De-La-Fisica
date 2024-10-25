using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    private bool isGrounded;
    private Vector3 velocity;      // Stores velocity, including jump velocity and gravity

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
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
        if (isGrounded && Input.GetKeyDown("space"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
