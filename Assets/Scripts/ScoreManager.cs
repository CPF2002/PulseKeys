using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro multText;
    public TMPro.TextMeshPro streakText;
    public GameObject finalScoreText;
    private TextMeshProUGUI textComponent;
    static int comboScore;
    static int hitMultiplier;
    static int streakCounter;
    static int hitNotes;
    static int maxScore;
    static int maxMultiplier;
    static int maxStreak;

    public GameObject targetObject; // Assign the other GameObject in the Inspector
    public GameObject levelCompleteScreen;

    private AudioSource targetAudioSource;

    public float startTime;
    public float audioLength;

    public static bool isLevelComplete;

    void Start()
    {
        Instance = this;
        comboScore = 0;
        hitMultiplier = 1;
        streakCounter = 0;
        isLevelComplete = false;
        hitNotes = 0;
        maxScore = 0;
        maxMultiplier = 1;
        maxStreak = 0;


        startTime = Time.time; // Record the initial time
        Debug.Log("Start Time: " + startTime + " seconds");
        levelCompleteScreen.SetActive(false);

        textComponent = finalScoreText.GetComponent<TextMeshProUGUI>();

        // Check if the target audio is assigned
        if (targetObject != null)
        {
            // Get the AudioSource from the target object
            targetAudioSource = targetObject.GetComponent<AudioSource>();

            if (targetAudioSource != null)
            {
                Debug.Log("AudioSource found on target object. #2");
                audioLength = targetAudioSource.clip.length;
                Debug.Log("Audio Length: " + audioLength + " seconds"); // after length + some seconds, stop time and show level complete screen
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
    public static void Hit()
    {
        // for what the user hits
        if (streakCounter >= 5)
        {
            hitMultiplier = 2;
        }
        streakCounter += 1;
        comboScore += 100 * hitMultiplier;
        Instance.hitSFX.Play();
        hitNotes++;

        // for the max score
        if (maxStreak >= 5)
        {
            maxMultiplier = 2;
        }
        maxStreak += 1;
        maxScore += 100 * maxMultiplier;
    }
    public static void Miss()
    {
        // for user misses
        hitMultiplier = 1;
        streakCounter = 0;
        Instance.missSFX.Play();    

        // for the max score
        if (maxStreak >= 5)
        {
            maxMultiplier = 2;
        }
        maxStreak += 1;
        maxScore += 100 * maxMultiplier;
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
        multText.text = hitMultiplier.ToString() + "x";
        streakText.text = "Streak: " + streakCounter.ToString();

        textComponent.text = "Final Score: " + scoreText.text + " / " + maxScore + "\n" + "Hit Notes: " + hitNotes + " / " + maxStreak;

        if (startTime + audioLength + 0.5 < Time.time)
        {
            isLevelComplete = true;
            Time.timeScale = 0f;
            levelCompleteScreen.SetActive(true);
            Debug.Log("Level Complete!");
            Debug.Log("startTime + audioLength + 0.5: "+ startTime + audioLength + 0.5);
            Debug.Log("Time.time: " + Time.time);
        }
    }
}
