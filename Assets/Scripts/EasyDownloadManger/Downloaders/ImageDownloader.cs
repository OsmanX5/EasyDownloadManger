using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
	class ImageDownloader : MonoBehaviour
	{
		public void DownLoadImage(string url, Action<Texture2D> OnDownloadComplete)
		{
			StartCoroutine(DownLoadImageRoutine(url, OnDownloadComplete));
		}

		public IEnumerator DownLoadImageRoutine(string url, Action<Texture2D> OnDownloadComplete)
		{
			Texture2D DownloadedTexture = null;
			UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
			yield return webRequest.SendWebRequest();
			if (webRequest.error != null)
			{
				DebugLog.AddMessege("Error happend");
				DebugLog.AddMessege(webRequest.error);
			}
			else
			{
				DebugLog.AddMessege("Success in recived the text from the server");
				DownloadedTexture = DownloadHandlerTexture.GetContent(webRequest);
				OnDownloadComplete(DownloadedTexture);
			}
		}
	}
}
