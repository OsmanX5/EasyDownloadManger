using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace EasyDownloadManger
{
	class TextDownloader : MonoBehaviour
	{
		public void DownLoadText(string url, Action<string> OnDownloadComplete,string fileName )
		{
			string FilePath = Application.persistentDataPath + "/" + fileName + ".txt";
			if (File.Exists(FilePath))
			{
				Debug.Log("file already downloaded");
				OnDownloadComplete(File.ReadAllText(FilePath));
			}
			StartCoroutine(DownLoadTextRoutine(url, OnDownloadComplete, FilePath));
		}

		IEnumerator DownLoadTextRoutine(string url, Action<string> OnDownloadComplete,string FilePath)
		{

			string DownloadedText = "";
			UnityWebRequest webRequest = UnityWebRequest.Get(url);
			yield return webRequest.SendWebRequest();
			if (webRequest.error != null)
			{
				Debug.Log("Error happend");
				Debug.Log(webRequest.error);
			}
			else
			{
				DownloadedText = webRequest.downloadHandler.text;
				File.WriteAllText(FilePath, DownloadedText);
				OnDownloadComplete(DownloadedText);
			}
		}


	}
}