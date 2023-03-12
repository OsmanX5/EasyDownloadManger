using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace EasyDownloadManger
{
	public class Downloader : MonoBehaviour
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
				GameObject Instantiated = GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
				Instantiated.name = "Downloader";
				_instance = Instantiated.AddComponent<Downloader>();
			}
			return _instance;
		}

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

		bool DownloadPreProccess(string url,string type)
		{
			IniaiteDownladerObject();
			DebugLog.Clear();
			DebugLog.AddMessege($"Function : EDM.Download{type}()");
			if (url.Length < 10)
			{
				DebugLog.AddMessege("Too short URL");
				return false;
			}
			DebugLog.AddMessege("Downolading . . . ");
			return true;
		}
		public void DownloadText(string url, Action<string> OnDownloadComplete)
		{
			if(DownloadPreProccess(url, "Text") == false) return;
			textDownloader.DownLoadText(url, OnDownloadComplete);
		}
		public void DownloadImage(string url, Action<Texture2D> OnDownloadComplete)
		{
			if (DownloadPreProccess(url, "Image") == false) return;
			imageDownloader.DownLoadImage(url, OnDownloadComplete);
		}
		public void DownloadAudioCLip(string url, Action<AudioClip> OnDownloadComplete, AudioType type = AudioType.MPEG)
		{
			if (DownloadPreProccess(url, "AudioClip") == false) return;
			audioDownloader.DownLoadAudioClip(url, OnDownloadComplete, type);
		}
		public void DownloadAssetBunddle(string url, Action<AssetBundle> OnDownloadComplete)
		{
			if (DownloadPreProccess(url, "AssetBunddle") == false) return;
			assetBunddleDownloader.DownloadAsset(url, OnDownloadComplete);
		}
		public void DownloadPrefabAsset(string url, Action<GameObject> OnDownloadComplete)
		{
			if (DownloadPreProccess(url, "PrefabAsset") == false) return;
			DownloadAssetBunddleSingleItem<GameObject>(url, OnDownloadComplete);
			
		}

		public void DownloadAssetBunddleSingleItem<T>(string url, Action<T> OnDownloadComplete) where T: UnityEngine.Object
		{
			if (DownloadPreProccess(url, "AssetBunddleSingleItem" +typeof(T)) == false) return;
			DownloadAssetBunddle(url, OnAssetDownloaded);
			void OnAssetDownloaded(AssetBundle downloadedAsset)
			{
				string assetName = downloadedAsset.GetAllAssetNames()[0];
				if (downloadedAsset.LoadAsset(assetName).GetType() != typeof(T))
				{
					DebugLog.AddMessege("Diffrent types");
					return;
				}

				T data = downloadedAsset.LoadAsset<T>(assetName);
				OnDownloadComplete(data);
			}
		}


	}

}
