using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipObjectBuilderManager : MonoBehaviour
{
    public List<GameObject> cannonPrefabs = new List<GameObject>();
    public List<GameObject> helmetPrefabs = new List<GameObject>();
    public List<GameObject> thrustersPrefabs = new List<GameObject>();
    public List<GameObject> extraPrefabs = new List<GameObject>();

    public GameObject shipObject;

    // Start is called before the first frame update
    void Start()
    {
/*        
        GameObject cannon = Instantiate(cannonPrefabs[0], shipObject.transform.position, Quaternion.identity);
        GameObject helmet = Instantiate(helmetPrefabs[0], shipObject.transform.position, Quaternion.identity);
        GameObject thrusters = Instantiate(thrustersPrefabs[0], shipObject.transform.position, Quaternion.identity);
        GameObject extra = Instantiate(extraPrefabs[1], shipObject.transform.position, Quaternion.identity);
        cannon.transform.parent = shipObject.transform;
        helmet.transform.parent = shipObject.transform;
        thrusters.transform.parent = shipObject.transform;
        extra.transform.parent = shipObject.transform;
        ship Ship = shipObject.GetComponent<ship>();
        Ship.SetParts(helmet, thrusters, extra, cannon);
*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
