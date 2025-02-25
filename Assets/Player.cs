using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager; 
    [SerializeField] private Transform cameraTransform; 

    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 10f; 
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private float groundCheckDistance = 0.1f; 

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump); 
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player script loaded");
    }

    private void Update()
    {
        // Check if the player is grounded
        CheckGrounded();
    }

    private void MovePlayer(Vector3 direction)
    {
        // Get the camera's forward and right vectors (flattened to ignore vertical rotation)
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on the camera's orientation
        Vector3 moveDirection = (cameraForward * direction.z) + (cameraRight * direction.x);
        moveDirection.Normalize();

        // Rotate the player to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        // Move the player using Rigidbody
        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
    }

    private void Jump()
    {
    Debug.Log("Jump method called");
    if (isGrounded)
    {
        Debug.Log("Player is grounded, applying jump force");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    else
    {
        Debug.Log("Player is not grounded, cannot jump");
    }
}

private void CheckGrounded()
{
    RaycastHit hit;
    isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance);

    if (isGrounded)
    {
        isGrounded = hit.collider.CompareTag("Ground");
    }

}

    private void OnDrawGizmos()
    {
        // Draw a debug line to visualize the ground check
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}