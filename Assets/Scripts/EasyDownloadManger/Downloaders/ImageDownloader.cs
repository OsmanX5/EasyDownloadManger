using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

namespace EasyDownloadManger
{
	class ImageDownloader : MonoBehaviour
	{

		public void DownLoadImage(string url, Action<Texture2D> OnDownloadComplete,string fileName)
		{
			string FilePath = Application.persistentDataPath + "/" + fileName + ".jpg";
			if (File.Exists(FilePath))
			{
				Debug.Log("file already downloaded");
				Texture2D texture = LoadImageFromDisk(FilePath);
				OnDownloadComplete(texture);
			}
			StartCoroutine(DownLoadImageRoutine(url, OnDownloadComplete, FilePath));
		}

		IEnumerator DownLoadImageRoutine(string url, Action<Texture2D> OnDownloadComplete,string FilePath)
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
				SaveImageToDisk(DownloadedTexture, FilePath);
				Debug.Log("Download done");
				OnDownloadComplete(DownloadedTexture);
			}
		}

		Texture2D LoadImageFromDisk(string FullFilePath)
		{
			byte[] textureBytes = File.ReadAllBytes(FullFilePath);
			Texture2D loadedTexture = new Texture2D(0, 0);
			loadedTexture.LoadImage(textureBytes);
			return loadedTexture;
		}

		void SaveImageToDisk(Texture2D texture, string FullFilePath)
		{
			byte[] textureBytes = texture.EncodeToJPG();
			File.WriteAllBytes(FullFilePath, textureBytes);
		}
	}
}
