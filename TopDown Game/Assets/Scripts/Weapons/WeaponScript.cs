using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponScript : ScriptableObject
{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;

    public void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.Log("no weapon equipped!");
            return;
        }
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        AudioManager.manager.Play("Weapon Throw");
    }
}
