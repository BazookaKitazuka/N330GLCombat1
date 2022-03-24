using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = new Vector2();

        movementVector.x = Input.GetAxis("Horizontal") * speed;

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, .4f, groundLayer) != null;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            movementVector.y = jumpForce;
        }

        if(movementVector.x < 0) {
            this.gameObject.transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
        }else {
            this.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }

        rb.AddForce(movementVector);
    }
}
