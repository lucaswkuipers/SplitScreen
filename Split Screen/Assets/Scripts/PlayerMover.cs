using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode jumpKey;

    [Header("Movement")]
    [SerializeField] float movementMultiplier;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float maximumVelocity;

    private bool isLeftKeyPressed = false;
    private bool isRightKeyPressed = false;
    private bool isJumpKeyPressed = false;

    private Rigidbody rigidBody;
    private Collider playerCollider;
    private float distanceToGround;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        distanceToGround = playerCollider.bounds.extents.y;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        ApplyInput();
        ClampVelocity();
    }

    private void ProcessInput()
    {
        isLeftKeyPressed = Input.GetKey(leftKey);
        isRightKeyPressed = Input.GetKey(rightKey);
        isJumpKeyPressed = Input.GetKey(jumpKey);
    }

    private void ApplyInput()
    {
        if (isLeftKeyPressed) { Move(Vector3.left); }
        if (isRightKeyPressed) { Move(Vector3.right); }
        if (isJumpKeyPressed && IsGrounded()) { Jump(); }
    }

    private void Move(Vector3 vector)
    {
        rigidBody.AddForce(vector * movementMultiplier * Time.deltaTime, ForceMode.Impulse);
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpMultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (float)(distanceToGround + 0.1));
    }

    private void ClampVelocity()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > maximumVelocity)
        {
            Vector3 newVelocity = rigidBody.velocity;
            newVelocity.x = Vector2.ClampMagnitude(rigidBody.velocity, maximumVelocity).x;
            rigidBody.velocity = newVelocity;
        }
    }
}
