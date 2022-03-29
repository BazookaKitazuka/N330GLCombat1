using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public float moveSpeed = 0.05f;
    private int timeout = 15;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "floor")
        {
            isGrounded = true;
        }
    }

    
    IEnumerator Destroy()
    {
        
        

            yield return new WaitForSeconds(timeout);
            Destroy(this.gameObject);
        
            
     
    }
    
  
}
