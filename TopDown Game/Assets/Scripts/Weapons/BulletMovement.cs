using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //shoot from FirePoint
        //get reference to direction
        direction = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);
        //destroy after 4 sec
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        //shoot bullet towards direction object
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
    }

}
