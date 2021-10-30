using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float GRAVITY_CONSTANT = -9.81f;

    public float mouseSensitivity = 100f;
    public float movementSpeed = 12f;
    public float gravity = 1f;

    private CharacterController characterController;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocity = new Vector3();
    }

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (characterController.isGrounded)
        {
            Debug.Log("CharacterController is grounded");
            velocity.y = -1f;

        }

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
        characterController.Move(move * movementSpeed * Time.deltaTime);
        
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        velocity.y += GRAVITY_CONSTANT * gravity * Mathf.Pow(Time.deltaTime, 2);
        characterController.Move(velocity);
    }
}
