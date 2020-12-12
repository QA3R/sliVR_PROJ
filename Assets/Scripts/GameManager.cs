using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = GameObject.FindObjectOfType<VideoPlayer>();
    }
   
    public void PauseGame()
    {
        _videoPlayer.Pause();
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        _videoPlayer.Play();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit sucessfully");
    }
}
