using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Simulence.Video
{
    public class VideoManager : MonoBehaviour
    {
        #region Variables
   
        [SerializeField] private List<VideoClip> videoClips;
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
        //Plays video clip based on string input (video file name)
        public void PlayVideo(string clipName)
        {
            for(var i =0; i < videoClips.Count; i++)
            {
                if (clipName == videoClips[i].name)
                {
                    videoPlayer.clip = videoClips[i];
                    videoPlayer.Play();
                    videoPlayer.isLooping = false;
                    Debug.Log("video clip: " + clipName + " was found");
                    break;
                }
            }
        }

        // Method will automatically play the 0th index clip (idle clip)
        public void PlayIdle(UnityEngine.Video.VideoPlayer vp)
        {
            if (videoClips[0] != null)
            {
                vp.clip = videoClips[0];
                vp.isLooping = true;
            }
        }

        #endregion
    }
}
