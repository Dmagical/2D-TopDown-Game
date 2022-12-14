using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public Camera cam;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");

    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
       
    }
}
