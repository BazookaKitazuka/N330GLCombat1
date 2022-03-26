using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{


    // Start is called before the first frame update
    PlayerController controls;
    float direction = 0;
    public float speed = 400;
    public bool isFacingLeft = true;
    public float jumpForce = 5;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D playerRB;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    private void Awake()
    {
        //player contrller
        controls = new PlayerController();
        controls.Enable();


        controls.Player2.Movement.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        controls.Player2.Jump.performed += context => Jump();
        // set health ints
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // chackes if player is on ground and the direction they are facing.
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);


        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        if (isFacingLeft && direction > 0 || !isFacingLeft && direction < 0)
            Flip();
    }
    // Changes player direction
    void Flip()
    {
        isFacingLeft = !isFacingLeft;
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
    // allows player to take damage
    void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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