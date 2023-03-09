using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	class TextDownloader : MonoBehaviour
	{
		public void DownLoadText(string url, Action<string> OnDownloadComplete)
		{
			StartCoroutine(DownLoadTextRoutine(url, OnDownloadComplete));
		}

		public IEnumerator DownLoadTextRoutine(string url, Action<string> OnDownloadComplete)
		{
			string DownloadedText = "";
			UnityWebRequest webRequest = UnityWebRequest.Get(url);
			yield return webRequest.SendWebRequest();
			if (webRequest.error != null)
			{
				DebugLog.AddMessege("Error happend");
				DebugLog.AddMessege(webRequest.error);
			}
			else
			{
				DebugLog.AddMessege("Success in reciving data");
				DownloadedText = webRequest.downloadHandler.text;
				OnDownloadComplete(DownloadedText);
			}
		}


	}
}