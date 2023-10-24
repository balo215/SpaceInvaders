using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public static ship Instance { get; private set; }
    public float moveSpeed; // Adjust the speed as needed
    private Rigidbody2D rb2D;
    public GameObject projectilePrefab;
    public Transform startPosition;
    public float fireRate = .5f; // Adjust the fire rate (time between shots)
    private float nextFireTime = 0f;
    public float rotationSpeed = 20f;
    private bool isAKeyPressed = false;
    private bool isDKeyPressed = false;
    private float originalRotation = 0f;
    private bool bulletStarterSet = false;

    public GameObject helmet;
    public GameObject thrusters;
    public GameObject cannon;
    public GameObject extra;
    public GameObject shipObject;
    public Transform bulletStarter;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();   
        originalRotation = transform.rotation.eulerAngles.y;

    }
    private void Awake(){
        if (Instance == null){
            // If no instance exists, set this as the instance
            Instance = this;

            // Make sure the GameObject is not destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }else{
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(bulletStarterSet == true){
              
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(angle, -90, 90));
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.velocity = movement * moveSpeed;
/*
        if (Input.GetKeyDown(KeyCode.Space)){
            // Shoot a projectile
            Shoot();
        } */
        if (Input.GetKeyDown(KeyCode.A) ){
            Debug.Log("pressing A");
            isAKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.A) ){
            isAKeyPressed = false;   
        }
        if (Input.GetKeyDown(KeyCode.D) ){
            Debug.Log("pressing D");
            isDKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.D) ){
            isDKeyPressed = false;   
        }
        if(Input.GetKeyDown(KeyCode.M)){
                    transform.position = new Vector3(0f, 0f, 0f);

        }
/*
        if(isAKeyPressed == true && isDKeyPressed == false){
            float rotation = -moveHorizontal * rotationSpeed * Time.deltaTime;
            if(transform.rotation.eulerAngles.y < 45){
                transform.Rotate(Vector3.up * rotation);
           //     Debug.Log(transform.rotation.eulerAngles.y);
            }
        }
        if(isAKeyPressed == false && isDKeyPressed == true){
         //       Debug.Log(transform.rotation.eulerAngles.y);
            float rotation = -moveHorizontal * rotationSpeed * Time.deltaTime;
            if(transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y == 0){
                transform.Rotate(Vector3.up * rotation);
            }
        }
        if(isAKeyPressed == false && isDKeyPressed == false ){
            float lerpSpeed =3f; // Adjust the speed of rotation recovery
            float currentRotation = transform.rotation.eulerAngles.y;
            float newRotation = Mathf.Lerp(currentRotation, originalRotation, lerpSpeed * Time.deltaTime);
            //Debug.Log(currentRotation);
            transform.rotation = Quaternion.Euler(0f, newRotation, 0f);
        }
       /* if (isHorizontalKeyPressed){
            float rotation = -moveHorizontal * rotationSpeed * Time.deltaTime;
            if(transform.rotation.eulerAngles.y < 45){
                transform.Rotate(Vector3.up * rotation);
                Debug.Log(transform.rotation.eulerAngles.y);
            }
        }else{
            float lerpSpeed =3f; // Adjust the speed of rotation recovery
            float currentRotation = transform.rotation.eulerAngles.y;
            float newRotation = Mathf.Lerp(currentRotation, originalRotation, lerpSpeed * Time.deltaTime);
            //Debug.Log(currentRotation);
            transform.rotation = Quaternion.Euler(0f, newRotation, 0f);
        }*/

    }

    public void SetParts(GameObject helmetPart, GameObject thrustersPart, GameObject extraPart, GameObject cannonPart, GameObject bulletPart){
        // Assign the provided GameObjects to the corresponding parts
        //helmet = helmetPart;
        helmet = Instantiate(helmetPart, transform.position, Quaternion.identity);
        helmet.transform.parent = shipObject.transform;
        thrusters = Instantiate(thrustersPart, transform.position, Quaternion.identity);
        thrusters.transform.parent = shipObject.transform;
        extra = Instantiate(extraPart, transform.position, Quaternion.identity);
        extra.transform.parent = shipObject.transform;
        cannon = Instantiate(cannonPart, transform.position, Quaternion.identity);
        cannon.transform.parent = shipObject.transform;                         
        bulletStarterSet = true;

        //Warning: this may be an issue if the structure is not correct 
        bulletStarter = cannon.transform.Find("MainCannon").Find("bulletStarter");
        projectilePrefab = bulletPart;

        moveSpeed = thrusters.GetComponent<Thruster>().GetSpeed() + helmet.GetComponent<Hull>().GetSpeed();
    }

    public void repositionShip(){
        Destroy(helmet);
        Destroy(thrusters);
        Destroy(extra);
        Destroy(cannon);
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
        bulletStarterSet = false;
        /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(angle, -90, 90));
*/
    }



}
