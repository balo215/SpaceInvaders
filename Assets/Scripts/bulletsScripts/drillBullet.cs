using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillBullet : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the speed as needed
    public float projectileSpeed = 10;
    public int damagePoints = 2;

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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);        
    }

    void OnBecameInvisible(){
        Destroy(gameObject); 
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        Destroy(gameObject);
    }

}
