using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class entering : MonoBehaviour
{
    public Button newBtn;
    public Button continueBtn;
    public Button deleteBtn;
    public GameObject saveSlotModal;

    // Start is called before the first frame update
    void Start()
    {
        
        // Add a click event listener to the button
        newBtn.onClick.AddListener(OnNewButtonClick);         
    }

    private void OnNewButtonClick(){
        newBtn.interactable = false;
        continueBtn.interactable = false;
        deleteBtn.interactable = false;
        saveSlotModal.SetActive(true);
    }

    private void OnDeleteButtonClick(string saveFile){
        PlayerSelectionManager.DeleteSaveData(saveFile);
        deleteBtn.interactable = false;
        continueBtn.interactable = false;

    }



}
