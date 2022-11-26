using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startHealth;
    public HealthBar HealthBar;
    private HealthSystem health;

    private Animator anim;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
       
        health = new HealthSystem(startHealth);
        HealthBar.Setup(health);

    }


    
    void Update()
    {
        //enemy dies
        if (health.GetHealth() == 0)
        {
            Destroy(boxCollider);
            anim.Play("death");
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject, 1f);
            AudioManager.manager.Play("Slime Death");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            AudioManager.manager.Play("Slime Hit");
            anim.SetTrigger("hit");
            health.Damage(GameObject.Find("Player").GetComponent<PlayerMovement>().currentWeapon.damage);
            Destroy(collision.gameObject);
        }

    }

}
