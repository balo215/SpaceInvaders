using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra : MonoBehaviour
{
    public ExtraConfig extraConfig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetPropertyLabel(){
        return extraConfig.propertyLabel;
    }
    public string GetName(){
        return extraConfig.extraName;
    }
}
