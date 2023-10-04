using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class shipSelectorEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        Debug.Log(otherCollider);
        if(otherCollider.CompareTag("Ship")){
            otherCollider.GetComponent<ship>().repositionShip();
            SceneManager.LoadScene("shipBuilder");
        }

    }
}
