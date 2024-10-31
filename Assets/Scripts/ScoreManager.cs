using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro multText;
    public TMPro.TextMeshPro streakText;
    static int comboScore;
    static int hitMultiplier;
    static int streakCounter;

    void Start()
    {
        Instance = this;
        comboScore = 0;
        hitMultiplier = 1;
        streakCounter = 0;
    }
    public static void Hit()
    {
        streakCounter += 100;
        if (streakCounter >= 5)
        {
            hitMultiplier = 300;
        }
        comboScore += 1 * hitMultiplier;
        Instance.hitSFX.Play();
    }
    public static void Miss()
    {
        hitMultiplier = 1;
        streakCounter = 0;
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
        multText.text = hitMultiplier.ToString() + "x";
        streakText.text = "Streak: " + streakCounter.ToString();

    }
}
