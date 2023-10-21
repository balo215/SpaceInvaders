using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierBehaviour : MonoBehaviour
{
    public GameObject ship;
    public float lifeTime = 5f;
    public float endLife;
    // Start is called before the first frame update
    void Start()
    {
        endLife = Time.time + lifeTime;
        ship = GameObject.Find("Ship");
        Debug.Log(ship.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-component is set to zero for an orthogonal view.
        Vector3 shootDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0,angle-90f));
        
        transform.position = ship.transform.position;
        if(endLife < Time.time){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        Debug.Log(otherCollider);
    }
}
