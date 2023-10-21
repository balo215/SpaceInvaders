using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juiceManager : MonoBehaviour
{
    private bool isGamePaused = false;
    public float shakeDuration = 0.15f;
    public float shakeMagnitude = 0.1f;
    public float elapsedTime = 0f;
    private float noiseSeed = 1f;

    public Camera mainCamera;
    public Vector3 originalPosition;

    void Start(){
        mainCamera.enabled = true;
        originalPosition = mainCamera.transform.localPosition;
    }

    void Update(){

    }

    public void drillHit(){
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine(){
        float elapsed = 0f;
        while (elapsed < shakeDuration){
            float x = Mathf.PerlinNoise(noiseSeed, 0) * 2 - 1;
            float y = Mathf.PerlinNoise(0, .4f) * 2 - 1;
            x *= shakeMagnitude;
            y *= shakeMagnitude;
            mainCamera.transform.localPosition = originalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            noiseSeed += Time.deltaTime * 20; // Adjust the speed of Perlin noise to control the shaking.
            yield return null;
        }
        mainCamera.transform.localPosition = originalPosition;
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
