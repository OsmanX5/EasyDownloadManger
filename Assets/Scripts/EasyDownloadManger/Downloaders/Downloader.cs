using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace EasyDownloadManger
{
    public class InterneDownloader : MonoBehaviour
    {
        public float DownloadProgress { get; set; }
        public void Download(UnityWebRequest request)
        {
            Debug.Log("Start Downloading . . .");
            StartCoroutine(DownLoadRoutine(request));
        }
        IEnumerator DownLoadRoutine(UnityWebRequest request)
        {
	        DownloadProgress = 0f;

			request.SendWebRequest();
            while (DownloadProgress <1f)
            {
	            DownloadProgress = request.downloadProgress;
	            yield return null;
            }

            DownloadProgress = 1f;

			if (request.error != null)
            {
                Debug.LogError(request.error);
            }
            else
            {
                OnResponse(request);
            }
           
        }
        protected virtual void OnResponse(UnityWebRequest request)
        {
            Debug.Log("Downloaded Susseccfully");
        }
    }
}
