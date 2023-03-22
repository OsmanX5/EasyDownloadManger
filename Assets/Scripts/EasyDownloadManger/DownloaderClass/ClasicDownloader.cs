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
        #region Public Methodes for Downloads
        public void DownloadText(string url, Action<string> OnDownloadComplete)
            => Download(url, OnDownloadComplete, InternetDownloaderType.Text);
        public void DownloadImage(string url, Action<Texture2D> OnDownloadComplete)
            => Download(url, OnDownloadComplete, InternetDownloaderType.Image);
        public void DownloadAudioCLip(string url, Action<AudioClip> OnDownloadComplete, AudioType type = AudioType.MPEG)
            => Download(url, OnDownloadComplete, InternetDownloaderType.Audio);
        public void DownloadAssetBunddle(string url, Action<AssetBundle> OnDownloadComplete)
            => Download(url, OnDownloadComplete, InternetDownloaderType.AssetBunddle);
        #endregion

        private void Download(string url, Delegate callBack, InternetDownloaderType type)
        {
            IniaiteDownladerObject();
            var selectedDownloader = SelectDownloader(type);
            SyncroniceProgressBar(selectedDownloader);
            selectedDownloader.Download(url, callBack);
        }
        private InterneDownloader SelectDownloader(InternetDownloaderType type)
        {
            switch (type)
            {
                case InternetDownloaderType.Text: return textDownloader;
                case InternetDownloaderType.Image: return imageDownloader;
                case InternetDownloaderType.Audio: return audioDownloader;
                case InternetDownloaderType.AssetBunddle: return assetBunddleDownloader;
            }
            Debug.LogError("Invalid type");
            return null;
        }
        
        private void SyncroniceProgressBar(InterneDownloader downloaderObject)
        {
            StartCoroutine(DownloadProgressBarUpdate(downloaderObject));
        }
        IEnumerator DownloadProgressBarUpdate(InterneDownloader downloaderObject)
		{
			while (downloaderObject.DownloadProgress <= 1f)
			{
				CurrentDownloadProgress = downloaderObject.DownloadProgress;
				if(downloaderObject.DownloadProgress >=1f) break;
				Debug.Log(CurrentDownloadProgress);
				yield return new WaitForSeconds(0.1f);
			}
		}


		
    }
}
