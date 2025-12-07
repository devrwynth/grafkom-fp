using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float movementSpeed = 0;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 2f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.8f;
    [SerializeField] LayerMask groundLayerMask;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping;
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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        controller.Move(movement * movementSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded && !isJumping)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime ;
        controller.Move(velocity* Time.deltaTime);
    }
}
