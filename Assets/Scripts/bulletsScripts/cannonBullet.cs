using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBullet : MonoBehaviour
{
    public float projectileSpeed = 10;
    public int damagePoints = 2;
    public GameObject obj;
    public BoxCollider2D collider;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-component is set to zero for an orthogonal view.
        Vector3 shootDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0,angle-90f));
        rb2D.velocity = shootDirection * 15f; 
        obj = new GameObject("CollidedObject");
        collider = obj.AddComponent<BoxCollider2D>(); // You can use other collider types like SphereCollider, CapsuleCollider, etc.
        collider.size = new Vector2(.1f, .1f);
        collider.transform.position = mousePosition; // Set the position as needed
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible(){
        destroySet();
    }

    void destroySet(){
        Destroy(gameObject);
        Destroy(obj);
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        if(otherCollider == collider){
            destroySet();
            GameObject explosionObject = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(explosionObject, .4f);
        }
    }

}
