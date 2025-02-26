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
    private int jumpCount = 0; 
    private const int maxJumps = 1; 

    private void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump);
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player script loaded");
    }

    private void Update()
    {
        CheckGrounded();
    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward * direction.z) + (cameraRight * direction.x);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
    }

    private void Jump()
    {
        Debug.Log("Jump method called");

        if (isGrounded || jumpCount < maxJumps)
        {
            Debug.Log("Applying jump force");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
        else
        {
            Debug.Log("Player cannot jump");
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance);

        if (isGrounded)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                jumpCount = 0;
            }
        }
        
    }
}