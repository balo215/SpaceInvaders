using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class entering : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        // Add a click event listener to the button
        button.onClick.AddListener(OnButtonClick);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)){
            // Load the specified scene
            Debug.Log("Entering");
            SceneManager.LoadScene("shipBuilder");
        }
    }

    private void OnButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene("shipBuilder");
        if (SceneManager.GetSceneByName("title").isLoaded){
            SceneManager.UnloadScene("title");
        }
    }



}
