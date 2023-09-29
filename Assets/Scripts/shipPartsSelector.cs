using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shipPartsSelector : MonoBehaviour
{
    public List<GameObject> thrustersPrefabs = new List<GameObject>();
    public List<GameObject> extraPrefabs = new List<GameObject>();
    public List<GameObject> hullPrefabs = new List<GameObject>();
    public List<GameObject> cannonPrefabs = new List<GameObject>();
    public List<GameObject> bulletPrefabs = new List<GameObject>();

    public GameObject thrusters;
    public GameObject extra;
    public GameObject hull;
    public GameObject cannon;
    public GameObject bullet;
    public GameObject shipObject;

    public GameObject thrusterPanel;
    public GameObject extraPanel;
    public GameObject hullPanel;
    public GameObject cannonPanel;

    public int thrusterIndex = 0;
    public int extraIndex = 0;
    public int hullIndex = 0;
    public int cannonIndex = 0;

    public Button nextThrusterButton; 
    public Button prevThrusterButton;
    public Button nextExtraButton;
    public Button prevExtraButton;
    public Button nextHullButton;
    public Button prevHullButton;
    public Button nextCannonButton;
    public Button prevCannonButton;
    public Button selectButton;

    public Camera uiCamera;
    public Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        thrusters = Instantiate(thrustersPrefabs[thrusterIndex], thrusterPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        extra = Instantiate(extraPrefabs[extraIndex], extraPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        hull = Instantiate(hullPrefabs[hullIndex], hullPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        cannon = Instantiate(cannonPrefabs[cannonIndex], cannonPanel.transform.position + new Vector3(0f, -3f, 0f), Quaternion.identity);
        // Set the Panel as the parent of the instantiated prefab
        ChangeLayerRecursively(thrusters, 5);
        ChangeLayerRecursively(extra, 5);
        ChangeLayerRecursively(hull, 5);
        ChangeLayerRecursively(cannon, 5);

        thrusters.transform.parent = thrusterPanel.transform;
        extra.transform.parent = extraPanel.transform;
        hull.transform.parent = hullPanel.transform;
        cannon.transform.parent = cannonPanel.transform;

        thrusters.transform.localScale = new Vector3(20, 20, 20);
        extra.transform.localScale = new Vector3(20, 20, 20);
        hull.transform.localScale = new Vector3(20, 20, 20);
        cannon.transform.localScale = new Vector3(60, 60, 60);

        nextThrusterButton.onClick.AddListener(nextThruster);
        prevThrusterButton.onClick.AddListener(prevThruster);
        nextExtraButton.onClick.AddListener(nextExtra);
        prevExtraButton.onClick.AddListener(prevExtra);
        nextHullButton.onClick.AddListener(nextHull);
        prevHullButton.onClick.AddListener(prevHull);
        nextCannonButton.onClick.AddListener(nextCannon);
        prevCannonButton.onClick.AddListener(prevCannon);

        selectButton.onClick.AddListener(selectShip);
        shipObject = GameObject.FindWithTag("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextThruster(){
        foreach (Transform child in thrusterPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(thrusterIndex == 1){
            thrusterIndex = 0;
        }else{
            thrusterIndex++;
        }
        setThruster();
    }
    public void prevThruster(){
        foreach (Transform child in thrusterPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(thrusterIndex == 0){
            thrusterIndex = 1;
        }else{
            thrusterIndex--;
        }
        setThruster();
    }
        public void nextExtra(){
        foreach (Transform child in extraPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(extraIndex == 1){
            extraIndex = 0;
        }else{
            extraIndex++;
        }
        setExtra();
    }
    public void prevExtra(){
        foreach (Transform child in extraPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(extraIndex == 0){
            extraIndex = 1;
        }else{
            extraIndex--;
        }
        setExtra();
    }
    public void nextHull(){
        foreach (Transform child in hullPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(hullIndex == 1){
            hullIndex = 0;
        }else{
            hullIndex++;
        }
        setHull();
    }
    public void prevHull(){
        foreach (Transform child in hullPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(hullIndex == 0){
            hullIndex = 1;
        }else{
            hullIndex--;
        }
        setHull();
    }

    public void nextCannon(){
        foreach (Transform child in cannonPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(cannonIndex == 1){
            cannonIndex = 0;
        }else{
            cannonIndex++;
        }
        setCannon();
    }
    public void prevCannon(){
        Debug.Log(shipObject);
        foreach (Transform child in cannonPanel.transform){
        // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        if(cannonIndex == 0){
            cannonIndex = 1;
        }else{
            cannonIndex--;
        }
        setCannon();
    }

    void setThruster(){
        thrusters = Instantiate(thrustersPrefabs[thrusterIndex], thrusterPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        ChangeLayerRecursively(thrusters, 5);
        thrusters.transform.parent = thrusterPanel.transform;
        thrusters.transform.localScale = new Vector3(20, 20, 20);
        // Set the Panel as the parent of the instantiated prefab
        
    }

    void setExtra(){
        extra = Instantiate(extraPrefabs[extraIndex], extraPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        ChangeLayerRecursively(extra, 5);
        extra.transform.parent = extraPanel.transform;
        extra.transform.localScale = new Vector3(20, 20, 20);

        // Set the Panel as the parent of the instantiated prefab
        
    }

    void setHull(){
        hull = Instantiate(hullPrefabs[hullIndex], hullPanel.transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
        ChangeLayerRecursively(hull, 5);
        hull.transform.parent = hullPanel.transform;
        hull.transform.localScale = new Vector3(20, 20, 20);

        // Set the Panel as the parent of the instantiated prefab
        
    }

    void setCannon(){
        cannon = Instantiate(cannonPrefabs[cannonIndex], cannonPanel.transform.position + new Vector3(0f, -3f, 0f), Quaternion.identity);
        ChangeLayerRecursively(cannon, 5);
        cannon.transform.parent = cannonPanel.transform;
        cannon.transform.localScale = new Vector3(60, 60, 60);
        // Set the Panel as the parent of the instantiated prefab
        
    }

    void selectShip(){
        shipObject.GetComponent<ship>().SetParts(hullPrefabs[hullIndex], thrustersPrefabs[thrusterIndex], extraPrefabs[extraIndex], cannonPrefabs[cannonIndex], bulletPrefabs[cannonIndex]);
        SceneManager.LoadScene("Menus");
        
    }

    public void ChangeLayerRecursively(GameObject targetObject, int layerNumber){
        // Change the layer of the current GameObject
        targetObject.layer = layerNumber;

        // Iterate through the child GameObjects
        foreach (Transform child in targetObject.transform)
        {
            // Recursively change the layer of each child
            ChangeLayerRecursively(child.gameObject, layerNumber);
        }
    }
}
