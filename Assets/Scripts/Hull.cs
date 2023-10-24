using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public HullConfig hullConfig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpeed(){
        return hullConfig.baseSpeed;
    }
    public string GetName(){
        return hullConfig.hullName;
    }

}
