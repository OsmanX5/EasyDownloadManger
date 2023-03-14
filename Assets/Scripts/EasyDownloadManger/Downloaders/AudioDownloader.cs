using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	public class AudioDownloader : InterneDownloader
    {
        Action<AudioClip> callBackFunction;
        public void DownLoadAudioClip(string url, Action<AudioClip> OnDownloadComplete, AudioType type=AudioType.MPEG)
        {
            callBackFunction = OnDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(url, type);
            Download(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            AudioClip DownloadedAudio = DownloadHandlerAudioClip.GetContent(Response);
            callBackFunction(DownloadedAudio);
        }
	}
}