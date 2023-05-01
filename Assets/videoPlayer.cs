using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour
{
   public string url;
   public VideoPlayer vidplayer;
   
   // Start is called before the first frame update
   void Start()
   {
       vidplayer = GetComponent<VideoPlayer>();
       vidplayer.url = "https://tobiasrisom.github.io/video/Title.mp4";
       Play();
   }

   void Play()
   {
       vidplayer.Play();
       vidplayer.isLooping = true;
   }
}
