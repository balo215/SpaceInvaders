using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceManager : MonoBehaviour
{
    private bool isGamePaused = false;
    public float shakeDuration = 0.15f;

    public float shakeAngle = 0.5f; // The maximum angle of rotation during the shake.
    private Quaternion originalRotation;


    public Camera mainCamera;
    public Vector3 originalPosition;

    void Start(){
        mainCamera.enabled = true;
        originalPosition = mainCamera.transform.localPosition;
        originalRotation = mainCamera.transform.rotation;
    }

    void Update(){

    }

    public void drillHit(){
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine(){
        float elapsed = 0f;
        while (elapsed < shakeDuration){

            float randomAngle = Random.Range(-shakeAngle, shakeAngle);
            Quaternion newRotation = Quaternion.Euler(0f, 0f, randomAngle);
            mainCamera.transform.rotation = newRotation;
            elapsed += Time.deltaTime;

            yield return null;
        }
        mainCamera.transform.rotation = originalRotation;
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
