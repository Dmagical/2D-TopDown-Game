using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth;
    public HealthBar HealthBar;
    private HealthSystem health;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        health = new HealthSystem(startHealth);

        HealthBar.Setup(health);
    }

    void Update()
    {
        //player dies
        if (health.GetHealth() == 0)
        {
            Destroy(gameObject.transform.GetChild(2).gameObject);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health.Damage(10);
        }

    }
}
