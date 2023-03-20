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
		static Downloader _instance;
		public static Downloader Instance
		{
			get => IniaiteDownladerObject();
		}

		static Downloader IniaiteDownladerObject()
		{
			if (_instance == null)
			{
				Debug.Log("Initate Downloader");
				GameObject Instantiated = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
				Instantiated.name = "Downloader";
				_instance = Instantiated.AddComponent<Downloader>();
			}
			return _instance;
		}

		public static float CurrentDownloadProgress { get; set; }
		TextDownloader textDownloader;
		ImageDownloader imageDownloader;
		AudioDownloader audioDownloader;
		AssetBunddleDownloader assetBunddleDownloader;
		void Awake()
		{
			textDownloader = this.AddComponent<TextDownloader>();
			imageDownloader = this.AddComponent<ImageDownloader>();
			audioDownloader = this.AddComponent<AudioDownloader>();
			assetBunddleDownloader = this.AddComponent<AssetBunddleDownloader>();
		}

		/*bool DownloadPreProccess(InterneDownloader downloaderType ,string url)
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
			textDownloader.DownLoadText(url, OnDownloadComplete);
		}
		public void DownloadImage(string url, Action<Texture2D> OnDownloadComplete)
		{
			if (DownloadPreProccess(imageDownloader,url) == false) return;
			imageDownloader.DownLoadImage(url, OnDownloadComplete);
		}
		public void DownloadAudioCLip(string url, Action<AudioClip> OnDownloadComplete, AudioType type = AudioType.MPEG)
		{
			if (DownloadPreProccess(audioDownloader,url) == false) return;
			audioDownloader.DownLoadAudioClip(url, OnDownloadComplete, type);
		}
		public void DownloadAssetBunddle(string url, Action<AssetBundle> OnDownloadComplete)
		{
			if (DownloadPreProccess(assetBunddleDownloader,url) == false) return;
			assetBunddleDownloader.DownloadAsset(url, OnDownloadComplete);
		}
		public void DownloadPrefabAsset(string url, Action<GameObject> OnDownloadComplete)
		{
			DownloadAssetBunddleSingleItem<GameObject>(url, OnDownloadComplete);
		}

		public void DownloadAssetBunddleSingleItem<T>(string url, Action<T> OnDownloadComplete) where T: UnityEngine.Object
		{
			DownloadAssetBunddle(url, OnAssetDownloaded);
			void OnAssetDownloaded(AssetBundle downloadedAsset)
			{
				string assetName = downloadedAsset.GetAllAssetNames()[0];
				if (downloadedAsset.LoadAsset(assetName).GetType() != typeof(T))
				{
					return;
				}

				T data = downloadedAsset.LoadAsset<T>(assetName);
				OnDownloadComplete(data);
			}
		}
		*/

	}

}
