using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private VideoClip[] vidClips;

    [SerializeField]
    public GameObject videoPlayerObj;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //videoPlayerObj = GameObject.Find("ScreenSpace");
        videoPlayer = videoPlayerObj.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayVideoClip(0);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayVideoClip(1);
        }
    }

    public void PlayVideoClip (int clipID)
    {
        videoPlayer.clip = vidClips[clipID];
        videoPlayer.Play();
    }

}
