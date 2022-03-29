using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public bool changeColorGreen = false;
    public bool changeColorYellow = false;
    public bool changeColorRed = false;
    public float switchYellow = 3.0f;
    private bool repeat = true;
    public float alpha = 0.2f;
    public GameObject player1;
    public GameObject player2;
    [SerializeField] int Damage;
    Vector3  lastPos;
    // Use this for initialization
    void Start()
    {
        // call color change
        StartCoroutine(color());
        
    }
    // Update is called once per frame
    IEnumerator color()
    {
        // random time interval on color green
        float switchGreen = Random.Range(5f, 10f);
        // random time interval on color red
        float switchRed = Random.Range(1f, 5f);
        // repeat the  background color change
        while (repeat == true){
            // change color from green to yellow
            if (changeColorGreen == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0, alpha);
                changeColorRed = false;
                changeColorYellow = true;
                yield return new WaitForSeconds(switchGreen);
            }
            // change color from yellow to red
            if (changeColorYellow == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0, alpha);
                changeColorGreen = false;
                changeColorRed = true;
                yield return new WaitForSeconds(switchYellow);
            }
            //change color from red to green
            if (changeColorRed == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0, alpha);
                changeColorYellow = false;
                changeColorGreen = true;
                yield return new WaitForSeconds(switchRed);
            }
            // color damage
            if(changeColorYellow == true && player1.transform.position != lastPos)
            {
                Damage = 7;
                gameObject.GetComponent<playerMovement>().TakeDamage(Damage);
            }
            if (changeColorYellow == true && player2.transform.position != lastPos)
            {
                Damage = 7;
                gameObject.GetComponent<Player2>().TakeDamage(Damage);
            }
        }

    }
 
}