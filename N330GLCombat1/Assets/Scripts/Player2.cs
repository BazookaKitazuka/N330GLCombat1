using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public Transform itemDetect;
    public Transform weaponSlot;
    public float rayDist;
    private bool inHand = false;
    private Animator animator;

    private void Awake()
    {
        //player contrller
        controls = new PlayerController();
        controls.Enable();

        animator = this.GetComponent<Animator>();

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
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    //picks up items
    void pickUp()
    {


        RaycastHit2D itemCheck = Physics2D.Raycast(itemDetect.position, transform.localScale, rayDist);
        if (itemCheck.collider != null && itemCheck.collider.tag == "Item")
        {
            if (Input.GetKey(KeyCode.Period))
            {
                itemCheck.collider.gameObject.transform.parent = weaponSlot;
                itemCheck.collider.gameObject.transform.position = weaponSlot.position;
                itemCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

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

    void Update() {
        // winer
        animator.SetFloat("Run", Mathf.Abs(playerRB.velocity.x));
        pickUp();
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Player1Win");

        }
    }
}