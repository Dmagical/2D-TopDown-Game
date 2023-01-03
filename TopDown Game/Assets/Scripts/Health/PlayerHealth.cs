using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth;
    public HealthBar HealthBar;
    public static HealthSystem playerHealth;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        playerHealth = new HealthSystem(startHealth);

        HealthBar.Setup(playerHealth);
    }

    void Update()
    {
        //player dies
        if (playerHealth.GetHealth() == 0)
        {
            Destroy(gameObject.transform.GetChild(2).gameObject);
            Destroy(gameObject);
            AudioManager.manager.Play("Player Death");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            playerHealth.Damage(10);
            AudioManager.manager.Play("Player Hit");
        }

    }
}
