using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    float xMovement;
    float zMovement;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform target;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        if (xMovement != 0 || zMovement != 0)
        {
            Vector3 movement = new Vector3(xMovement, 0, zMovement);
            rb.velocity = movement * speed;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, target.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
        Destroy(bullet, 3f);
    }
}
