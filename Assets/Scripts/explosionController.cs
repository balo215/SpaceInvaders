using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionController : MonoBehaviour
{
    public GameObject sparksPS;
    public ParticleSystem smoke;
    public ParticleSystem sparks;
    public juiceManager jm;


    // Start is called before the first frame update
    void Start()
    {
        jm = FindObjectOfType<juiceManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        Time.timeScale = 1;
        if(otherCollider.CompareTag("Enemy")){
            jm.PauseGame(.035f);
            sparksPS.SetActive(true);

        }
    }


}
