using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceManager : MonoBehaviour
{
    private bool isGamePaused = false;
    public Camera mainCamera;

    void Start(){
        mainCamera.enabled = true;
    }

    public void PauseGame(float duration){
        if (!isGamePaused){
            isGamePaused = true;
            mainCamera.orthographicSize = 9.95f;
            //Time.timeScale = 0f; 
            StartCoroutine(ResumeAfterDelay(duration));
        }
    }

    // Coroutine to resume the game after a delay
    private IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        //Time.timeScale = 1.0f; // Set time scale back to normal (1)
        isGamePaused = false;
        mainCamera.orthographicSize = 10f;
    }

}
