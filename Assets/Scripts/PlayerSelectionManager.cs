using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSelection{
    public int SelectedCannon;
    public int SelectedHull;
    public int SelectedThrusters;
    public int SelectedAbility;
    public string SelectedSaveFileName;
}

public class PlayerSelectionManager : MonoBehaviour
{


    private static PlayerSelectionManager instance;
    private static string currentSaveFile;

    // Ensures only one instance of PlayerSelectionManager exists
    private void Awake()    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private const string SaveFilePrefix = "SaveFile_";

    // Save player selections for a specific save file
    public static void SaveSelections(string saveFile, int cannon, int hull, int thrusters, int ability, string saveFileName){
        string cannonKey = SaveFilePrefix + saveFile + "_SelectedCannon";
        string hullKey = SaveFilePrefix + saveFile + "_SelectedHull";
        string thrustersKey = SaveFilePrefix + saveFile + "_SelectedThrusters";
        string abilityKey = SaveFilePrefix + saveFile + "_SelectedAbility";
        string fileKey = SaveFilePrefix + saveFile + "_SelectedSaveFile"; 

        PlayerPrefs.SetInt(cannonKey, cannon);
        PlayerPrefs.SetInt(hullKey, hull);
        PlayerPrefs.SetInt(thrustersKey, thrusters);
        PlayerPrefs.SetInt(abilityKey, ability);
        PlayerPrefs.SetString(fileKey, saveFileName);
        PlayerPrefs.Save();
        SetCurrentSaveFile(saveFile);
    }

    // Load player selections for a specific save file
    public static PlayerSelection LoadSelections(string saveFileIndex){
        PlayerSelection playerSelection = new PlayerSelection();
        playerSelection.SelectedCannon = PlayerPrefs.GetInt(SaveFilePrefix + saveFileIndex + "_SelectedCannon", -1);
        playerSelection.SelectedHull = PlayerPrefs.GetInt(SaveFilePrefix + saveFileIndex + "_SelectedHull", -1);
        playerSelection.SelectedThrusters = PlayerPrefs.GetInt(SaveFilePrefix + saveFileIndex + "_SelectedThrusters", -1);
        playerSelection.SelectedAbility = PlayerPrefs.GetInt(SaveFilePrefix + saveFileIndex + "_SelectedAbility", -1);
        playerSelection.SelectedSaveFileName = PlayerPrefs.GetString(SaveFilePrefix + saveFileIndex + "_SelectedSaveFile", "");
        return playerSelection;
    }

    public static void DeleteSaveData(string saveFileIndex){
        PlayerPrefs.DeleteKey(SaveFilePrefix + saveFileIndex + "_SelectedCannon");
        PlayerPrefs.DeleteKey(SaveFilePrefix + saveFileIndex + "_SelectedHull");
        PlayerPrefs.DeleteKey(SaveFilePrefix + saveFileIndex + "_SelectedThrusters");
        PlayerPrefs.DeleteKey(SaveFilePrefix + saveFileIndex + "_SelectedAbility");
        PlayerPrefs.DeleteKey(SaveFilePrefix + saveFileIndex + "_SelectedSaveFile");
        PlayerPrefs.Save();
    }

    public static bool HasSaveData(string saveFileIndex){
        return PlayerPrefs.HasKey(SaveFilePrefix + saveFileIndex + "_SelectedCannon");
        // You can choose any key to check; if one key exists, it means there's save data.
    }


    public static void SetCurrentSaveFile(string saveFile){
        currentSaveFile = saveFile;
    }

    public static string GetCurrentSaveFile(){
        return currentSaveFile;
    }
}
