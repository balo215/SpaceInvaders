using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{
    private int healthPoints = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0){
            Destroy(gameObject);
        }
    }

        void OnTriggerEnter2D(Collider2D otherCollider){
        Debug.Log(otherCollider);
        if(otherCollider.CompareTag("Projectile")){
            
            int DP = otherCollider.GetComponent<drillBullet>().damagePoints;

            healthPoints = healthPoints - DP;
            Debug.Log(DP);
        }

        //Destroy(gameObject);
    }
}
