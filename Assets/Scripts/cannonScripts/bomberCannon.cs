using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberCannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject bulletStarter;
    private float nextFireTime = 1f;
    private float fireRate = .1f;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime){
            // Shoot a projectile
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot(){
        if (Time.time >= nextFireTime){
            GameObject newProjectile = Instantiate(projectilePrefab, bulletStarter.transform.position, Quaternion.identity);
        }   
    }
}
