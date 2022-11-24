using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] weapons;

    public float xBound, yBound;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAWeapon());
    }

    IEnumerator SpawnAWeapon()
    {
        yield return new WaitForSeconds(10);
        Vector2 spawnPoint = new Vector2(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound));
        //if less than 3 weapons on map, spawn one
        if (GameObject.FindGameObjectsWithTag("Weapon").Length < 3)
        Instantiate(weapons[Random.Range(0, weapons.Length)], spawnPoint, Quaternion.identity);
        StartCoroutine(SpawnAWeapon());

    }
}
