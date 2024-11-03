using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class VideoController : MonoBehaviour
{
    
    public int currentVideo = 0;
    public VideoPlayer videoPlayer;
    public string videoFolder = "Videos/MacArthurBates";
    public Button forward;
    public Button backward;
    public Button play;
    public TMP_Text wordDisplay;
    void Start()
    {
        wordDisplay.text = GameSettings.wordsPerLevel[currentVideo];
        videoPlayer.clip = Resources.Load<VideoClip>(Path.Combine(videoFolder, GameSettings.wordsPerLevel[currentVideo]));
    }
    void Update()
    {
        if(currentVideo == 0)
        {
            backward.interactable = false;
        }
        else
        {
            backward.interactable = true;
        }
        if(currentVideo == 4)
        {
            forward.interactable = false;
            play.interactable = true;
        }
        else
        {
            forward.interactable = true;
        }

    }
    public void previousVideo()
    {
        if(currentVideo > 0)
        {
            currentVideo--;
        }
        wordDisplay.text = GameSettings.wordsPerLevel[currentVideo];
        videoPlayer.clip = Resources.Load<VideoClip>(Path.Combine(videoFolder, GameSettings.wordsPerLevel[currentVideo]));
    }
    public void nextVideo()
    {
        if(currentVideo < 4)
        {
            currentVideo++;
        }
        wordDisplay.text = GameSettings.wordsPerLevel[currentVideo];
        videoPlayer.clip = Resources.Load<VideoClip>(Path.Combine(videoFolder, GameSettings.wordsPerLevel[currentVideo]));
    }
}
