using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1); // Can be strign for specific scene name
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

}
