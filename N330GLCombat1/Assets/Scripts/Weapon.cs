using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public float moveSpeed = 0.05f;
    private int timeout = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }
   
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 4f, groundLayer);
    }
    IEnumerator Destroy()
    {
       
        
            yield return new WaitForSeconds(timeout);
        
            Destroy(this.gameObject);
     
    }
    
  
}
