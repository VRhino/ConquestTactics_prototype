using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Captures player input and forwards squad commands and interactions.
/// </summary>
public class HeroInputController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private MovementSettings movementSettings;
    [SerializeField] private Transform cameraPivot;

    [Header("Input Axes")]
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";
    [SerializeField] private string mouseXAxis = "Mouse X";
    [SerializeField] private string mouseYAxis = "Mouse Y";

    [Header("Keys")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    [Header("References")]
    [SerializeField] private SquadCommandSystem commandSystem;

    public UnityEvent onFormationMenu;

    public Transform currentTarget;

    private Rigidbody rb;
    private Vector3 movementInput;
    private bool jumpRequested;
    private float lookInput;
    private float pitchInput;

    private SupplyPointController currentSupplyPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (commandSystem == null)
            commandSystem = GetComponent<SquadCommandSystem>();
    }

    private void Update()
    {
        ReadMovementInput();
        ReadCommandInput();
        ReadInteractionInput();
    }

    private void ReadMovementInput()
    {
        float h = Input.GetAxisRaw(horizontalAxis);
        float v = Input.GetAxisRaw(verticalAxis);
        movementInput = new Vector3(h, 0f, v).normalized;

        lookInput = Input.GetAxis(mouseXAxis);
        pitchInput = Input.GetAxis(mouseYAxis);

        if (Input.GetKeyDown(jumpKey))
            jumpRequested = true;
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            float speed = movementSettings != null ? movementSettings.moveSpeed : 5f;
            Vector3 move = transform.TransformDirection(movementInput) * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            if (jumpRequested)
            {
                float force = movementSettings != null ? movementSettings.jumpForce : 5f;
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                jumpRequested = false;
            }
        }

        if (cameraPivot != null)
        {
            float sensitivity = movementSettings != null ? movementSettings.lookSensitivity : 2f;
            cameraPivot.Rotate(Vector3.up, lookInput * sensitivity, Space.World);
            cameraPivot.Rotate(Vector3.right, -pitchInput * sensitivity, Space.Self);
        }
    }

    private void ReadCommandInput()
    {
        if (commandSystem == null)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            commandSystem.IssueCommand(SquadCommandSystem.SquadCommand.Follow);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            commandSystem.IssueCommand(SquadCommandSystem.SquadCommand.HoldPosition);

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentTarget != null)
            commandSystem.IssueCommand(SquadCommandSystem.SquadCommand.AttackTarget, currentTarget);

        if (Input.GetKeyDown(KeyCode.Tab))
            onFormationMenu?.Invoke();
    }

    private void ReadInteractionInput()
    {
        if (currentSupplyPoint != null && Input.GetKeyDown(interactKey))
        {
            currentSupplyPoint.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var sp = other.GetComponent<SupplyPointController>();
        if (sp != null)
            currentSupplyPoint = sp;
    }

    private void OnTriggerExit(Collider other)
    {
        var sp = other.GetComponent<SupplyPointController>();
        if (sp != null && sp == currentSupplyPoint)
            currentSupplyPoint = null;
    }
}
