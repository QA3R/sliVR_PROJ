using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    #region Variables
   
    [SerializeField] private VideoClip[] vidClips;
    [SerializeField] public GameObject videoPlayerObj;
    private VideoPlayer videoPlayer;
  
    #endregion

    #region Start and OnDisable Method 
 
    // Start is called before the first frame update
    // Subscribes to the VideoPlayer.loopPointReached event
    void Start()
    {
        videoPlayer = videoPlayerObj.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += PlayIdle;
    }

    // Unsubscribes from the VideoPlayer.loopPointReach event when disabled
    private void OnDisable()
    {
        videoPlayer.loopPointReached -= PlayIdle;
    }

    #endregion

    #region Methods

    // Plays a video clip based on the passed int
    public void PlayVideoClip (int clipID)
    {
        if (vidClips[clipID] != null)
        {
            videoPlayer.clip = vidClips[clipID];
            videoPlayer.Play();
            videoPlayer.isLooping = false;
        }
    }

    // Method will automatically play the 0th index clip (idle clip)
    public void PlayIdle(UnityEngine.Video.VideoPlayer vp)
    {
        if (vidClips[0] != null)
        {
            vp.clip = vidClips[0];
            vp.isLooping = true;
        }
    }

    #endregion
}
