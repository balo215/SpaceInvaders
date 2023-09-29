using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillCannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject bulletStarter;
    private float nextFireTime = 0;
    private float fireRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime){
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
