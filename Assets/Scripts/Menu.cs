using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string songName;
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1); // Can be strign for specific scene name
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void OnMainMenuButton ()
    {
        SceneManager.LoadScene(0);
    }

    public void SongButton ()
    {
        SceneManager.LoadScene(songName);
    }

}
