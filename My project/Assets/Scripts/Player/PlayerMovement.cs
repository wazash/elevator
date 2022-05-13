using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 10f;

    private float gravity = -9.8f;
    private float groundedGravity = -2f;
    private Vector3 velocity;

    private void Update()
    {
        Movement();
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = groundedGravity;
        }
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(speed * Time.deltaTime * move);
    }
}
