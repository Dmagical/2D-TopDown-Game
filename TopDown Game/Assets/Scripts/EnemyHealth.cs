using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;


    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            Destroy(collision.gameObject);
        }
    }
}
