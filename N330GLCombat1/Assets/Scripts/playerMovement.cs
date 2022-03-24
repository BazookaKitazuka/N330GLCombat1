using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

   
    // Start is called before the first frame update
    PlayerController controls;
    float direction = 0;
    public float speed = 400;
    public bool isFacingRight = true;

    public float jumpForce = 5;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    

    private void Awake()
    {
        controls = new PlayerController();
        controls.Enable();

        controls.Player.Movement.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        controls.Player.Jump.performed += context => Jump();

    }
    // chackes if player is on ground and the direction they are facing.
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
       

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }
    // Changes player direction
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    // makes player jump
    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;   
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}