using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponDamage : MonoBehaviour
{
    public Weapon wp;
    [SerializeField] int Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerMovement>().TakeDamage(Damage);
        }
        if (collision.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player2>().TakeDamage(Damage);
        }
    }

}

