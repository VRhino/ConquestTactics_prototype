using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            // Add Rigidbody if it doesn't exist
            rb = gameObject.AddComponent<Rigidbody>();
            // Configure Rigidbody for top-down movement
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Create movement vector
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        // Apply movement in FixedUpdate for consistent physics
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Move the player using physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}