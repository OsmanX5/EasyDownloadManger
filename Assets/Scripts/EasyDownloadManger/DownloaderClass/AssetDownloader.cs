using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace EasyDownloadManger
{
	public partial class Downloader : MonoBehaviour
	{
		public void DownloadPrefabAsset(string url, Action<GameObject> OnDownloadComplete)
		{
			DownloadAssetBunddleSingleItem<GameObject>(url, OnDownloadComplete);
		}

		public void DownloadVideoAsset(string url, Action<VideoClip> OnDownloadComplete)
		{
			DownloadAssetBunddleSingleItem<VideoClip>(url, OnDownloadComplete);
		}

		public void DonwloadVideoAssetAsGameObject(string url, Action<GameObject> OnDownloadComplete)
		{
			DownloadAssetBunddleSingleItem<VideoClip>(url, OnVideoDownloaded);

			void OnVideoDownloaded(VideoClip video)
			{
				Debug.Log("Created video");
				GameObject videoGameObject = new GameObject("Video");
				VideoPlayer videoPlayer = videoGameObject.AddComponent<VideoPlayer>();
				videoPlayer.clip = video;
				videoPlayer.targetTexture = new RenderTexture(1920, 1080, 24);
				videoPlayer.Play();
				OnDownloadComplete(videoGameObject);
			}
		}
		public void DownloadAssetBunddleSingleItem<T>(string url, Action<T> OnDownloadComplete) where T : UnityEngine.Object
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
	}
}
