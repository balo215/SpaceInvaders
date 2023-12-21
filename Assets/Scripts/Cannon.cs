using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public CannonConfig cannonConfig;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetFireRate(){
        return cannonConfig.fireRate;
    }
    public float GetDamage(){
        return cannonConfig.damage;
    }
    public string GetName(){
        return cannonConfig.CannonName;
    }
}
