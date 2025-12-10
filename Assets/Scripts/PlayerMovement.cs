using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float movementSpeed = 0;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float movementSmoothTime = 0.5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.8f;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform secondPosition;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping;
    Vector3 currentMoveVelocity;
    Vector3 moveDampVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundLayerMask);
        if (isGrounded && velocity.y < 0f) {
            velocity.y = -2f;
        }
        if (!isGrounded)
        {
            isJumping = false;
        }
        Vector3 PlayerInput = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );
        
        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }
        Vector3 moveVector = transform.TransformDirection(PlayerInput);

        currentMoveVelocity = Vector3.SmoothDamp(
            currentMoveVelocity,
            moveVector*movementSpeed,
            ref moveDampVelocity,
            movementSmoothTime

        );
        controller.Move(currentMoveVelocity * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded && !isJumping)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime ;
        controller.Move(velocity* Time.deltaTime);

        if (Input.GetKey(KeyCode.O))
        {
            transform.position = startPosition.position;
        }
        if (Input.GetKey(KeyCode.P))
        {
            transform.position = secondPosition.position;
        }
    }
}
