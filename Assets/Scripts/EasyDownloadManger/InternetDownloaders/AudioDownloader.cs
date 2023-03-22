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
        public void Download(string url, Action<AudioClip> OnDownloadComplete)
        {
	        OnDownloadCompleteCallBack = OnDownloadComplete;
            UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
            StartDownloadingWithRequest(webRequest);
        }
        protected override void OnResponse(UnityWebRequest Response)
        {
            base.OnResponse(Response);
            AudioClip DownloadedAudio = DownloadHandlerAudioClip.GetContent(Response);
            OnDownloadCompleteCallBack.DynamicInvoke(DownloadedAudio);
        }
	}
}