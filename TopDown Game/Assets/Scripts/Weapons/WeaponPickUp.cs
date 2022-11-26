using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public WeaponScript weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().currentWeapon = weapon;
            AudioManager.manager.Play("Weapon Pickup");
            
            
            Destroy(gameObject);
            
        }
    }
}
