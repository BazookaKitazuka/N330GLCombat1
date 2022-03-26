using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   
    public float moveSpeed = 0.05f;
    public float timeout = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timeout());
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        transform.Translate(0, -moveSpeed, 0);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeout);
        Destroy(this.gameObject);
    }

}
