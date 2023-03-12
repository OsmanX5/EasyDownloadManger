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
				Debug.Log("Error happend");
				Debug.Log(webRequest.error);
			}
			else
			{
				DownloadedTexture = DownloadHandlerTexture.GetContent(webRequest);
				OnDownloadComplete(DownloadedTexture);
			}
		}
	}
}
