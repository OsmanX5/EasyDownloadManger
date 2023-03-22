using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace EasyDownloadManger
{
	public partial class Downloader : MonoBehaviour
	{
		bool DownloadPreProccess(InterneDownloader downloaderType ,string url)
		{
			IniaiteDownladerObject();
			if (url.Length < 10)return false;
			StartCoroutine(DownloadProcess(downloaderType));
			return true;
		}
		IEnumerator DownloadProcess(InterneDownloader downloaderObject)
		{
			while (downloaderObject.DownloadProgress <= 1f)
			{
				CurrentDownloadProgress = downloaderObject.DownloadProgress;
				if(downloaderObject.DownloadProgress >=1f) break;
				Debug.Log(CurrentDownloadProgress);
				yield return new WaitForSeconds(0.1f);
			}
		}
		public void DownloadText(string url, Action<string> OnDownloadComplete)
		{
			if(DownloadPreProccess(textDownloader,url) == false) return;
			textDownloader.Donwload(url, OnDownloadComplete);
		}
		public void DownloadImage(string url, Action<Texture2D> OnDownloadComplete)
		{
			if (DownloadPreProccess(imageDownloader,url) == false) return;
			imageDownloader.Download(url, OnDownloadComplete);
		}
		public void DownloadAudioCLip(string url, Action<AudioClip> OnDownloadComplete, AudioType type = AudioType.MPEG)
		{
			if (DownloadPreProccess(audioDownloader,url) == false) return;
			audioDownloader.Download(url, OnDownloadComplete);
		}
		public void DownloadAssetBunddle(string url, Action<AssetBundle> OnDownloadComplete)
		{
			if (DownloadPreProccess(assetBunddleDownloader,url) == false) return;
			assetBunddleDownloader.Download(url, OnDownloadComplete);
		}
	}
}
