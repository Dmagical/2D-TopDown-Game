using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (health < 1)
        {
            Destroy(boxCollider);
            anim.Play("death");
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            anim.SetTrigger("hit");
            health -= GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage;
            Destroy(collision.gameObject);
        }

    }
}
