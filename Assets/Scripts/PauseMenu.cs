using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public GameObject targetObject; // Assign the other GameObject in the Inspector

    private AudioSource targetAudioSource;
    
    void Start()
    {
        pauseMenu.SetActive(false);

        if (targetObject != null)
        {
            // Get the AudioSource from the target object
            targetAudioSource = targetObject.GetComponent<AudioSource>();

            if (targetAudioSource != null)
            {
                Debug.Log("AudioSource found on target object.");
            }
            else
            {
                Debug.LogWarning("No AudioSource found on target object.");
            }
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
        targetAudioSource.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false; 
        targetAudioSource.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(1);
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current level
    }
}
