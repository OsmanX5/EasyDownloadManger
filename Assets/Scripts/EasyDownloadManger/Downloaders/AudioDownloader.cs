using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	public class AudioDownloader : MonoBehaviour
	{
		public void DownLoadAudioClip(string url, Action<AudioClip> OnDownloadComplete, AudioType type)
		{
			StartCoroutine(DownLoadAudioClipRoutine(url, OnDownloadComplete, type));
		}

		public IEnumerator DownLoadAudioClipRoutine(string url, Action<AudioClip> OnDownloadComplete, AudioType type)
		{
			AudioClip DownloadedAudio = null;
			UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(url, type);
			yield return webRequest.SendWebRequest();
			if (webRequest.error != null)
			{
				DebugLog.AddMessege("Error happend");
				DebugLog.AddMessege(webRequest.error);
			}
			else
			{
				DebugLog.AddMessege("Success in reciving audioclip");
				DownloadedAudio = DownloadHandlerAudioClip.GetContent(webRequest);
				OnDownloadComplete(DownloadedAudio);
			}
		}
	}
}