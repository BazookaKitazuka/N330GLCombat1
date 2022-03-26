using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public float timeout = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timeout());
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        transform.Translate(0, -moveSpeed, 0);
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeout);
        Destroy(this.gameObject);
    }

}
