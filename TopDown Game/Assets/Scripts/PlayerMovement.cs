using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //weapon
    public WeaponScript currentWeapon;
    public GameObject bullet;
    private float nextTimeOfFire = 0;

    //moving
    public Animator anim;
    public float moveSpeed;
    public float runSpeed;
    public Rigidbody2D rb;

    Vector2 movement;

    //health
    private bool hit = true;
    [SerializeField]
    private int health;

    //grameObject grndchild to use in Update()
    private GameObject grandChild;

    private void Start()
    {
        //ref to "Aim", child of "Player"
        GameObject child = transform.GetChild(1).gameObject;
        //ref to "Weapon", child of "Aim", using child gameObject
        grandChild = child.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        //changes weapon sprite depending on current weapon equipped
        grandChild.transform.GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;


        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        //shooting
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }
        }
    }

    void FixedUpdate()
    {
        //animaiton conditions
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        //moving
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //running
        if (movement.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            rb.MovePosition(rb.position + movement * (moveSpeed + runSpeed) * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    IEnumerator HitBoxOf()
    {
        hit = false;
        yield return new WaitForSeconds(0.7f);
        hit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            if (hit == true)
            {
            StartCoroutine(HitBoxOf());
            health--;
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            
        }
        
    }


}
