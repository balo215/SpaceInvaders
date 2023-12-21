using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class newGameModal : MonoBehaviour
{
    public Button goBtn;
    public TMP_InputField userName;
    // Start is called before the first frame update
    void Start()
    {
        goBtn.onClick.AddListener(goBtnClick);  

    }

    void Update(){
        if(userName.text == ""){
            goBtn.interactable = false;
        }else{
            goBtn.interactable = true;
        }
    }

    public void goBtnClick(){
        string fileName = PlayerSelectionManager.GetCurrentSaveFile();
        PlayerSelectionManager.SaveSelections(fileName, -1, -1, -1, -1, userName.text);

        SceneManager.LoadScene("shipBuilder");
        if (SceneManager.GetSceneByName("title").isLoaded){
            SceneManager.UnloadScene("title");
        }
    }
    
}
