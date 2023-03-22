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
	}

}
