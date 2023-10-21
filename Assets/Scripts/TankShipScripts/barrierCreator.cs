using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierCreator : MonoBehaviour
{
    public GameObject barrierPrefab;
    public float nextBarrierTime = 0f;
    public GameObject barrier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextBarrierTime){
            Vector3 barrierPosition = new Vector3(transform.position.x, transform.position.y, 0);
            barrier = Instantiate(barrierPrefab, barrierPosition, Quaternion.identity);
            nextBarrierTime = Time.time + 8f;
        }
    }

}
