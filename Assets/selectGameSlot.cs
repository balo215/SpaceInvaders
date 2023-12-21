using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class selectGameSlot : MonoBehaviour
{
    public Button firstBtn;
    public Button secondBtn;
    public Button thirdBtn;
    public GameObject inputModal;
    public TMP_Text saveFileText_1;
    public TMP_Text saveFileText_2;
    public TMP_Text saveFileText_3;
    // Start is called before the first frame update
    void Start()
    {
        firstBtn.onClick.AddListener(() => onBtnClick("saveFile001"));
        secondBtn.onClick.AddListener(() => onBtnClick("saveFile010"));
        thirdBtn.onClick.AddListener(() => onBtnClick("saveFile100"));
        PlayerSelection playerSelection1 = PlayerSelectionManager.LoadSelections("saveFile001");
        PlayerSelection playerSelection2 = PlayerSelectionManager.LoadSelections("saveFile010");
        PlayerSelection playerSelection3 = PlayerSelectionManager.LoadSelections("saveFile100");
        if(playerSelection1.SelectedSaveFileName != ""){
            saveFileText_1.text = playerSelection1.SelectedSaveFileName;
        }
        if(playerSelection2.SelectedSaveFileName != ""){
            saveFileText_2.text = playerSelection2.SelectedSaveFileName;
        }
        if(playerSelection3.SelectedSaveFileName != ""){
            saveFileText_3.text = playerSelection3.SelectedSaveFileName;
        }
        
    }

    public void onBtnClick(string saveFile){
        inputModal.SetActive(true);
        this.gameObject.SetActive(false);
        PlayerSelectionManager.SaveSelections(saveFile, -1, -1, -1, -1, "");
    }
    
}
