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
        public void Download(UnityWebRequest request)
        {
            Debug.Log("Start Downloading . . .");
            StartCoroutine(DownLoadRoutine(request));
        }
        IEnumerator DownLoadRoutine(UnityWebRequest request)
        {
            yield return request.SendWebRequest();
            if(request.error != null)
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
